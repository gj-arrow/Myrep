namespace Task.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrlImage_and_ShortBio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Performers", "ShortBiography", c => c.String());
            AddColumn("dbo.Performers", "UrlImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Performers", "UrlImage");
            DropColumn("dbo.Performers", "ShortBiography");
        }
    }
}
