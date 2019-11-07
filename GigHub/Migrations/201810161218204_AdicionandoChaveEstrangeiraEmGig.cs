namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoChaveEstrangeiraEmGig : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Gigs", name: "Artista_Id", newName: "ArtistaID");
            RenameColumn(table: "dbo.Gigs", name: "genero_Id", newName: "GenreID");
            RenameIndex(table: "dbo.Gigs", name: "IX_Artista_Id", newName: "IX_ArtistaID");
            RenameIndex(table: "dbo.Gigs", name: "IX_genero_Id", newName: "IX_GenreID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Gigs", name: "IX_GenreID", newName: "IX_genero_Id");
            RenameIndex(table: "dbo.Gigs", name: "IX_ArtistaID", newName: "IX_Artista_Id");
            RenameColumn(table: "dbo.Gigs", name: "GenreID", newName: "genero_Id");
            RenameColumn(table: "dbo.Gigs", name: "ArtistaID", newName: "Artista_Id");
        }
    }
}
