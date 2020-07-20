namespace CrudClientes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Tipo = c.String(unicode: false),
                        CpfCnpj = c.String(unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        Telefone = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.cliente");
        }
    }
}
