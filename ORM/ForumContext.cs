namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ORM.Entities;

    public partial class ForumContext : DbContext
    {
        public ForumContext()
            : base("name=ForumConnection")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentVote> CommentVotes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<TopicVote> TopicVotes { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UsersToRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CommentVotes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Topics)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TopicVotes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.UserInfo)
                .WithRequired(e => e.User);
        }
    }
}
