namespace MVCSystemDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateViewModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Student", "FirstMidName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "FirstMidName", c => c.String());
            AlterColumn("dbo.Student", "LastName", c => c.String());
        }
    }
}
