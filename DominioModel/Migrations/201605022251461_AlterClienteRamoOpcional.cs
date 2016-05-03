namespace DominioModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterClienteRamoOpcional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cliente", "RamoAtividadeID", "dbo.RamoAtividade");
            DropIndex("dbo.Cliente", new[] { "RamoAtividadeID" });
            AlterColumn("dbo.Cliente", "RamoAtividadeID", c => c.Int());
            CreateIndex("dbo.Cliente", "RamoAtividadeID");
            AddForeignKey("dbo.Cliente", "RamoAtividadeID", "dbo.RamoAtividade", "RamoAtividadeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "RamoAtividadeID", "dbo.RamoAtividade");
            DropIndex("dbo.Cliente", new[] { "RamoAtividadeID" });
            AlterColumn("dbo.Cliente", "RamoAtividadeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Cliente", "RamoAtividadeID");
            AddForeignKey("dbo.Cliente", "RamoAtividadeID", "dbo.RamoAtividade", "RamoAtividadeID", cascadeDelete: true);
        }
    }
}
