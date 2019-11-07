namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoTabelaGig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Local = c.String(),
                        Artista_Id = c.String(maxLength: 128),
                        genero_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artista_Id)
                .ForeignKey("dbo.Genres", t => t.genero_Id)
                .Index(t => t.Artista_Id)
                .Index(t => t.genero_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "genero_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artista_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "genero_Id" });
            DropIndex("dbo.Gigs", new[] { "Artista_Id" });
            DropTable("dbo.Gigs");
            DropTable("dbo.Genres");
        }
    }
}
