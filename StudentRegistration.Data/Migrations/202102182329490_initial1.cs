namespace StudentRegistration.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Class", "OwnerID", c => c.Guid(nullable: false));
            AddColumn("dbo.Course", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Teacher", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Student", "OwnerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Class", "Name", c => c.String());
            AlterColumn("dbo.Teacher", "FullName", c => c.String());
            AlterColumn("dbo.Student", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Teacher", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Class", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Student", "OwnerId");
            DropColumn("dbo.Teacher", "OwnerId");
            DropColumn("dbo.Course", "OwnerId");
            DropColumn("dbo.Class", "OwnerID");
        }
    }
}
