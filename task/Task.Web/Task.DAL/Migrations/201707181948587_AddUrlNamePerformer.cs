namespace Task.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrlNamePerformer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Performers", "UrlName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Performers", "UrlName");
        }
    }
}
