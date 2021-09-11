namespace StudentWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDefaultColumnNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "SId", c => c.Int(nullable: false));
            AddColumn("dbo.User", "FirstName", c => c.String());
            AddColumn("dbo.User", "LastName", c => c.String());
            AddColumn("dbo.User", "ContactNo", c => c.String());
            AddColumn("dbo.User", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.User", "Grade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Grade");
            DropColumn("dbo.User", "Age");
            DropColumn("dbo.User", "ContactNo");
            DropColumn("dbo.User", "LastName");
            DropColumn("dbo.User", "FirstName");
            DropColumn("dbo.User", "SId");
        }
    }
}
