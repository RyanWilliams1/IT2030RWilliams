namespace EnrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(),
                        CourseDescription = c.String(),
                        CourseCredits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentLastName = c.String(),
                        StudentFirstName = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropIndex("dbo.Enrollments", new[] { "StudentID" });
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
        }
    }
}
