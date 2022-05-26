namespace TesteCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniciandoProjeto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "IdImovel", "dbo.Imoveis");
            AddForeignKey("dbo.Clientes", "IdImovel", "dbo.Imoveis", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "IdImovel", "dbo.Imoveis");
            AddForeignKey("dbo.Clientes", "IdImovel", "dbo.Imoveis", "Id", cascadeDelete: true);
        }
    }
}
