namespace EnrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Address1", c => c.String());
            AddColumn("dbo.Students", "Address2", c => c.String());
            AddColumn("dbo.Students", "City", c => c.String());
            AddColumn("dbo.Students", "Zip", c => c.String());
            AddColumn("dbo.Students", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "State");
            DropColumn("dbo.Students", "Zip");
            DropColumn("dbo.Students", "City");
            DropColumn("dbo.Students", "Address2");
            DropColumn("dbo.Students", "Address1");
        }
    }
}
