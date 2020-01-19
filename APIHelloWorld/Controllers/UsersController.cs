using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIHelloWorld.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace APIHelloWorld.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly DBContext DBContext;

        public UsersController(DBContext context)
        {
            DBContext = context;
        }

        // GET: api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return DBContext.Users.Include(u => u.Group);
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return DBContext.Users
                .Where(user => user.Id == id)
                .Include(u => u.Group)
                .FirstOrDefault();
        }
         
        // POST api/users
        [HttpPost]
        public void Post([FromBody]User user)
        {
            DBContext.Users.Add(user);
            DBContext.SaveChanges();
        }

        // PUT api/users/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {
            var oldUser = DBContext.Users.Where(user => user.Id == id).FirstOrDefault();

            if (oldUser != default(User))
            {
                oldUser.Email = user.Email;
                oldUser.GroupId = user.GroupId;
                oldUser.Name = user.Name;
                DBContext.Users.Update(oldUser);
                DBContext.SaveChanges();
            }
        }

        // DELETE api/users/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = DBContext.Users.Where(user => user.Id == id).FirstOrDefault();

            if (user != default(User))
            {
                DBContext.Users.Remove(user);
                DBContext.SaveChanges();
            }
        }
    }
}
