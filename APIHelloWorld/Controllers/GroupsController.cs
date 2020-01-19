using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIHelloWorld.Infrastructure;

namespace APIHelloWorld.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : Controller
    {
        private readonly DBContext DBContext;

        public GroupsController(DBContext context)
        {
            DBContext = context;
        }

        // GET: api/groups
        [HttpGet]
        public IEnumerable<Group> Get()
        {
            return DBContext.Groups;
        }

        // GET api/groups/id
        [HttpGet("{id}")]
        public Group Get(int id)
        {
            return DBContext.Groups.Where(group => group.Id == id).FirstOrDefault();
        }

        // POST api/groups
        [HttpPost]
        public void Post([FromBody]Group group)
        {
            DBContext.Groups.Add(group);
            DBContext.SaveChanges();
        }

        // PUT api/groups/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Group group)
        {
            var oldGroup = DBContext.Groups.Where(group => group.Id == id).FirstOrDefault();

            if (oldGroup != default(Group))
            {
                oldGroup.Name = group.Name;
                DBContext.Groups.Update(oldGroup);
                DBContext.SaveChanges();
            }
        }

        // DELETE api/groups/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var group = DBContext.Groups.Where(group => group.Id == id).FirstOrDefault();

            if (group != default(Group))
            {
                DBContext.Groups.Remove(group);
                DBContext.SaveChanges();
            }
        }
    }
}
