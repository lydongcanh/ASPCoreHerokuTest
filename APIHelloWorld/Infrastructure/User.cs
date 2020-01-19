using System;

namespace APIHelloWorld.Infrastructure
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // from the group model (Entity framework will connect the Primarykey and foreign key)
        public Group Group { get; set; }
        public int GroupId { get; set; }

        public User() { }
    }
}
