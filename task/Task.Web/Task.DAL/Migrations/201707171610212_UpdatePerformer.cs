namespace Task.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePerformer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Performers", "Views", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Performers", "Views", c => c.Int(nullable: false));
        }
    }
}
