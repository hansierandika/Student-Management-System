namespace StudentWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDefaultColumnNames1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "SId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "SId", c => c.Int(nullable: false));
        }
    }
}
