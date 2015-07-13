namespace RDFindAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publicaciones",
                c => new
                    {
                        IDPublicacion = c.Int(nullable: false, identity: true),
                        IDMarca = c.Int(nullable: false),
                        IDModelo = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDColor = c.Int(nullable: false),
                        IDTipoCombustible = c.Int(nullable: false),
                        IDTipoVehiculo = c.Int(nullable: false),
                        IDCondicion = c.Int(nullable: false),
                        IDUser = c.Int(nullable: false),
                        WDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDPublicacion)
                .ForeignKey("dbo.Colores", t => t.IDColor, cascadeDelete: true)
                .ForeignKey("dbo.Condiciones", t => t.IDCondicion, cascadeDelete: true)
                .ForeignKey("dbo.Marcas", t => t.IDMarca, cascadeDelete: true)
                .ForeignKey("dbo.Modelos", t => t.IDModelo, cascadeDelete: false)
                .ForeignKey("dbo.TipoCombustible", t => t.IDTipoCombustible, cascadeDelete: true)
                .ForeignKey("dbo.TipoVehiculo", t => t.IDTipoVehiculo, cascadeDelete: true)
                .Index(t => t.IDMarca)
                .Index(t => t.IDModelo)
                .Index(t => t.IDColor)
                .Index(t => t.IDTipoCombustible)
                .Index(t => t.IDTipoVehiculo)
                .Index(t => t.IDCondicion);
            
            CreateIndex("dbo.Imagenes", "IDPublicacion");
            AddForeignKey("dbo.Imagenes", "IDPublicacion", "dbo.Publicaciones", "IDPublicacion", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publicaciones", "IDTipoVehiculo", "dbo.TipoVehiculo");
            DropForeignKey("dbo.Publicaciones", "IDTipoCombustible", "dbo.TipoCombustible");
            DropForeignKey("dbo.Publicaciones", "IDModelo", "dbo.Modelos");
            DropForeignKey("dbo.Publicaciones", "IDMarca", "dbo.Marcas");
            DropForeignKey("dbo.Imagenes", "IDPublicacion", "dbo.Publicaciones");
            DropForeignKey("dbo.Publicaciones", "IDCondicion", "dbo.Condiciones");
            DropForeignKey("dbo.Publicaciones", "IDColor", "dbo.Colores");
            DropIndex("dbo.Imagenes", new[] { "IDPublicacion" });
            DropIndex("dbo.Publicaciones", new[] { "IDCondicion" });
            DropIndex("dbo.Publicaciones", new[] { "IDTipoVehiculo" });
            DropIndex("dbo.Publicaciones", new[] { "IDTipoCombustible" });
            DropIndex("dbo.Publicaciones", new[] { "IDColor" });
            DropIndex("dbo.Publicaciones", new[] { "IDModelo" });
            DropIndex("dbo.Publicaciones", new[] { "IDMarca" });
            DropTable("dbo.Publicaciones");
        }
    }
}
