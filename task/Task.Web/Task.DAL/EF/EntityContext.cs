using System.Collections.Generic;
using System.Data.Entity;
using Task.DAL.Entities;

namespace Task.DAL.EF
{
    public class EntityContext : DbContext
    {
        public DbSet<Accord> Accords { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Song> Songs { get; set; }

        public EntityContext(string connectionString)
            : base(connectionString)
        {
        }

        public EntityContext()
            : base("TaskDb")
        {
        }
    }
}
