namespace Task.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoubleToIntWithThousands : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "Views", c => c.Int(nullable: false));
            AlterColumn("dbo.Performers", "Views", c => c.Int(nullable: false));
            AlterColumn("dbo.Performers", "CountOfSongs", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Performers", "CountOfSongs", c => c.Double(nullable: false));
            AlterColumn("dbo.Performers", "Views", c => c.Double(nullable: false));
            AlterColumn("dbo.Songs", "Views", c => c.Double(nullable: false));
        }
    }
}
