namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLogMessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeOccured = c.DateTime(nullable: false),
                        Level = c.Int(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogMessages");
        }
    }
}
