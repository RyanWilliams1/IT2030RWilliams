namespace RyansEventManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventTypes", "EventTypeName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.EventTypes", "EventTypeDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventTypes", "EventTypeDescription", c => c.String());
            DropColumn("dbo.EventTypes", "EventTypeName");
        }
    }
}
