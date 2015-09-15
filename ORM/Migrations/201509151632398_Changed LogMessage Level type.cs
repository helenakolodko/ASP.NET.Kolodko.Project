namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedLogMessageLeveltype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogMessages", "Level", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogMessages", "Level", c => c.Int(nullable: false));
        }
    }
}
