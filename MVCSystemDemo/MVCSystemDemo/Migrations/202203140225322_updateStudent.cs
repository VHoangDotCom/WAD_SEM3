namespace MVCSystemDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Secret", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Secret");
        }
    }
}
