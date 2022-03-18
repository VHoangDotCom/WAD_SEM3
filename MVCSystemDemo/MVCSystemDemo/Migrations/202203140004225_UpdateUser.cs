namespace MVCSystemDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Course", newName: "Courses");
            RenameTable(name: "dbo.Enrollment", newName: "Enrollments");
            RenameTable(name: "dbo.Student", newName: "Students");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Students", newName: "Student");
            RenameTable(name: "dbo.Enrollments", newName: "Enrollment");
            RenameTable(name: "dbo.Courses", newName: "Course");
        }
    }
}
