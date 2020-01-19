using System;
using Microsoft.EntityFrameworkCore;

namespace APIHelloWorld.Infrastructure
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; private set; }
        public DbSet<Group> Groups { get; private set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    }
}
