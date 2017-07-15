namespace Task.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "Biography", c => c.String());
            AddColumn("dbo.Songs", "Views", c => c.Int(nullable: false));
            AddColumn("dbo.Performers", "Views", c => c.Int(nullable: false));
            AddColumn("dbo.Performers", "CountOfSongs", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Performers", "CountOfSongs");
            DropColumn("dbo.Performers", "Views");
            DropColumn("dbo.Songs", "Views");
            DropColumn("dbo.Songs", "Biography");
        }
    }
}
