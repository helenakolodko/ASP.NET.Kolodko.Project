namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateAddedunderlyingtype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Topics", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Topics", "DateAdded", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Users", "DateAdded", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Comments", "DateAdded", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
