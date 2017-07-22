namespace Task.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addURlVideo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "UrlVideo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "UrlVideo");
        }
    }
}
