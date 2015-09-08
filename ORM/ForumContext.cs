using System.Data.Entity;
using ORM.Entities;

namespace ORM
{
    public partial class ForumContext: DbContext
    {
        public ForumContext()
            : base("name=ForumConnection")
        {  }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
