namespace TesteCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                        ClienteAtivo = c.Boolean(nullable: false),
                        IdImovel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Imoveis", t => t.IdImovel, cascadeDelete: true)
                .Index(t => t.IdImovel);
            
            CreateTable(
                "dbo.Imoveis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoNegocio = c.String(nullable: false),
                        ValorImovel = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        ImovelAtivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "IdImovel", "dbo.Imoveis");
            DropIndex("dbo.Clientes", new[] { "IdImovel" });
            DropTable("dbo.Imoveis");
            DropTable("dbo.Clientes");
        }
    }
}
