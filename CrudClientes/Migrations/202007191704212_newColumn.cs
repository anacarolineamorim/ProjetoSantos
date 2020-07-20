namespace CrudClientes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cliente", "Excluido", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.cliente", "Excluido");
        }
    }
}
