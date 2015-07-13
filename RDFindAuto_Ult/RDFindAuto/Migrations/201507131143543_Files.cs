namespace RDFindAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PublicacionId = c.Int(nullable: false),
                        Publicacion_IDPublicacion = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Publicaciones", t => t.Publicacion_IDPublicacion)
                .Index(t => t.Publicacion_IDPublicacion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "Publicacion_IDPublicacion", "dbo.Publicaciones");
            DropIndex("dbo.Files", new[] { "Publicacion_IDPublicacion" });
            DropTable("dbo.Files");
        }
    }
}
