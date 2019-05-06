namespace RyansEventManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "EventTitle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Events", "EventDescription", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EventDescription", c => c.String());
            AlterColumn("dbo.Events", "EventTitle", c => c.String(nullable: false));
        }
    }
}
