namespace DominioModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClienteDataNascimento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "DataNascimento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "DataNascimento");
        }
    }
}
