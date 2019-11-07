namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConvencoesGigsGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artista_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gigs", "genero_Id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Artista_Id" });
            DropIndex("dbo.Gigs", new[] { "genero_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gigs", "Local", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gigs", "Artista_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Gigs", "genero_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Gigs", "Artista_Id");
            CreateIndex("dbo.Gigs", "genero_Id");
            AddForeignKey("dbo.Gigs", "Artista_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Gigs", "genero_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "genero_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artista_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "genero_Id" });
            DropIndex("dbo.Gigs", new[] { "Artista_Id" });
            AlterColumn("dbo.Gigs", "genero_Id", c => c.Byte());
            AlterColumn("dbo.Gigs", "Artista_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Gigs", "Local", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Gigs", "genero_Id");
            CreateIndex("dbo.Gigs", "Artista_Id");
            AddForeignKey("dbo.Gigs", "genero_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Gigs", "Artista_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
