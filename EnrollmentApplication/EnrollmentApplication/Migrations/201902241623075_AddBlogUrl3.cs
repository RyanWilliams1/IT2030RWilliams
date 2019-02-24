namespace EnrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogUrl3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseTitle", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Enrollments", "Grade", c => c.String(nullable: false));
            AlterColumn("dbo.Enrollments", "AssignedCampus", c => c.String(nullable: false));
            AlterColumn("dbo.Enrollments", "EnrollmentSemester", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "StudentLastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "StudentFirstName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentFirstName", c => c.String());
            AlterColumn("dbo.Students", "StudentLastName", c => c.String());
            AlterColumn("dbo.Enrollments", "EnrollmentSemester", c => c.String());
            AlterColumn("dbo.Enrollments", "AssignedCampus", c => c.String());
            AlterColumn("dbo.Enrollments", "Grade", c => c.String());
            AlterColumn("dbo.Courses", "CourseTitle", c => c.String());
        }
    }
}
