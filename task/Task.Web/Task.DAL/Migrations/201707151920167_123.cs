namespace Task.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlImage = c.String(),
                        Song_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.Song_Id)
                .Index(t => t.Song_Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Text = c.String(),
                        Performer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Performers", t => t.Performer_Id)
                .Index(t => t.Performer_Id);
            
            CreateTable(
                "dbo.Performers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Performer_Id", "dbo.Performers");
            DropForeignKey("dbo.Accords", "Song_Id", "dbo.Songs");
            DropIndex("dbo.Songs", new[] { "Performer_Id" });
            DropIndex("dbo.Accords", new[] { "Song_Id" });
            DropTable("dbo.Performers");
            DropTable("dbo.Songs");
            DropTable("dbo.Accords");
        }
    }
}
