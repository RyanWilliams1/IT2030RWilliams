namespace RyansEventManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventType_EventTypeDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventType_EventTypeDescription");
        }
    }
}
