namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.CommentVotes",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CommentId = c.Int(nullable: false),
                        Up = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CommentId })
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        AuthorId = c.Int(nullable: false),
                        SectionId = c.Int(),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Info = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TopicVotes",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        Up = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.TopicId })
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.UserInfos",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        About = c.String(maxLength: 255),
                        BirthDate = c.DateTime(storeType: "date"),
                        AvatarPath = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UsersToRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfos", "UserId", "dbo.Users");
            DropForeignKey("dbo.TopicVotes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Topics", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.TopicVotes", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Comments", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.UsersToRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UsersToRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.CommentVotes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.CommentVotes", "CommentId", "dbo.Comments");
            DropIndex("dbo.UsersToRoles", new[] { "UserId" });
            DropIndex("dbo.UsersToRoles", new[] { "RoleId" });
            DropIndex("dbo.UserInfos", new[] { "UserId" });
            DropIndex("dbo.TopicVotes", new[] { "TopicId" });
            DropIndex("dbo.TopicVotes", new[] { "UserId" });
            DropIndex("dbo.Topics", new[] { "SectionId" });
            DropIndex("dbo.Topics", new[] { "AuthorId" });
            DropIndex("dbo.CommentVotes", new[] { "CommentId" });
            DropIndex("dbo.CommentVotes", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "TopicId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropTable("dbo.UsersToRoles");
            DropTable("dbo.UserInfos");
            DropTable("dbo.TopicVotes");
            DropTable("dbo.Sections");
            DropTable("dbo.Topics");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.CommentVotes");
            DropTable("dbo.Comments");
        }
    }
}
