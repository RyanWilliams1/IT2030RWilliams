namespace EnrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ZipCode", c => c.String());
            DropColumn("dbo.Students", "Zip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Zip", c => c.String());
            DropColumn("dbo.Students", "ZipCode");
        }
    }
}
