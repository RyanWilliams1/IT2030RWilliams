namespace RyansEventManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        EventTypeID = c.Int(nullable: false, identity: true),
                        EventTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.EventTypeID);
            
            AddColumn("dbo.Events", "EventType_EventTypeID", c => c.Int());
            CreateIndex("dbo.Events", "EventType_EventTypeID");
            AddForeignKey("dbo.Events", "EventType_EventTypeID", "dbo.EventTypes", "EventTypeID");
            DropColumn("dbo.Events", "EventType_EventTypeDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventType_EventTypeDescription", c => c.String());
            DropForeignKey("dbo.Events", "EventType_EventTypeID", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "EventType_EventTypeID" });
            DropColumn("dbo.Events", "EventType_EventTypeID");
            DropTable("dbo.EventTypes");
        }
    }
}
