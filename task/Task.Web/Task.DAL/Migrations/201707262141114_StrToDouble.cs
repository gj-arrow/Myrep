namespace Task.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StrToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "Views", c => c.Double(nullable: false));
            AlterColumn("dbo.Performers", "Views", c => c.Double(nullable: false));
            AlterColumn("dbo.Performers", "CountOfSongs", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Performers", "CountOfSongs", c => c.String());
            AlterColumn("dbo.Performers", "Views", c => c.String());
            AlterColumn("dbo.Songs", "Views", c => c.String());
        }
    }
}
