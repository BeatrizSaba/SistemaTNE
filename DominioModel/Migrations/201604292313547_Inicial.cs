namespace DominioModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bairro",
                c => new
                    {
                        BairroID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        CidadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BairroID)
                .ForeignKey("dbo.Cidade", t => t.CidadeID)
                .Index(t => t.CidadeID);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        CidadeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        UFID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CidadeID)
                .ForeignKey("dbo.UF", t => t.UFID)
                .Index(t => t.UFID);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoID = c.Int(nullable: false, identity: true),
                        CEP = c.String(nullable: false, maxLength: 8, fixedLength: true, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 60),
                        BairroID = c.Int(nullable: false),
                        CidadeID = c.Int(nullable: false),
                        UFID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoID)
                .ForeignKey("dbo.UF", t => t.UFID)
                .ForeignKey("dbo.Cidade", t => t.CidadeID)
                .ForeignKey("dbo.Bairro", t => t.BairroID)
                .Index(t => t.CEP, unique: true, name: "UNQ_CEP")
                .Index(t => t.BairroID)
                .Index(t => t.CidadeID)
                .Index(t => t.UFID);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        DataCriacao = c.DateTime(nullable: false, storeType: "date"),
                        DataModificacao = c.DateTime(nullable: false, storeType: "date"),
                        Nome = c.String(nullable: false, maxLength: 70),
                        TipoPessoa = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Residencia = c.String(nullable: false, maxLength: 20),
                        EnderecoID = c.Int(nullable: false),
                        FrequenciaVisitaPosto = c.Int(),
                        FormaPagamentoUsada = c.Int(),
                        RamoAtividadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID)
                .ForeignKey("dbo.RamoAtividade", t => t.RamoAtividadeID, cascadeDelete: true)
                .ForeignKey("dbo.Endereco", t => t.EnderecoID)
                .Index(t => t.EnderecoID)
                .Index(t => t.RamoAtividadeID);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        ContatoID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        Nome = c.String(maxLength: 40),
                        Telefone = c.String(maxLength: 14),
                    })
                .PrimaryKey(t => t.ContatoID)
                .ForeignKey("dbo.Cliente", t => t.ClienteID)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        MarcaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.MarcaID);
            
            CreateTable(
                "dbo.MudancaEstadoCliente",
                c => new
                    {
                        ClienteID = c.Int(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        EstadoAnterior = c.Int(nullable: false),
                        EstadoNovo = c.Int(nullable: false),
                        Observacao = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => new { t.ClienteID, t.DataModificacao })
                .ForeignKey("dbo.Cliente", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.Posto",
                c => new
                    {
                        PostoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PostoID);
            
            CreateTable(
                "dbo.RamoAtividade",
                c => new
                    {
                        RamoAtividadeID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RamoAtividadeID);
            
            CreateTable(
                "dbo.Servico",
                c => new
                    {
                        ServicoID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ServicoID);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        VeiculoID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        Modelo = c.String(maxLength: 30),
                        Placa = c.String(maxLength: 7, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.VeiculoID)
                .ForeignKey("dbo.Cliente", t => t.ClienteID)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.UF",
                c => new
                    {
                        UFID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UFID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 30),
                        Senha = c.String(nullable: false, maxLength: 30),
                        Nome = c.String(nullable: false, maxLength: 40),
                        Papel = c.Int(nullable: false),
                        Bloqueado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .Index(t => t.Login, unique: true, name: "UNQ_LOGIN");
            
            CreateTable(
                "dbo.ClientesMarcasPreferidas",
                c => new
                    {
                        ClienteID = c.Int(nullable: false),
                        MarcaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClienteID, t.MarcaID })
                .ForeignKey("dbo.Cliente", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Marca", t => t.MarcaID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.MarcaID);
            
            CreateTable(
                "dbo.ClientesPostosFavoritos",
                c => new
                    {
                        ClienteID = c.Int(nullable: false),
                        PostoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClienteID, t.PostoID })
                .ForeignKey("dbo.Cliente", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Posto", t => t.PostoID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.PostoID);
            
            CreateTable(
                "dbo.ClientesServicosUtilizados",
                c => new
                    {
                        ClienteID = c.Int(nullable: false),
                        ServicoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClienteID, t.ServicoID })
                .ForeignKey("dbo.Cliente", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Servico", t => t.ServicoID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.ServicoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "BairroID", "dbo.Bairro");
            DropForeignKey("dbo.Endereco", "CidadeID", "dbo.Cidade");
            DropForeignKey("dbo.Endereco", "UFID", "dbo.UF");
            DropForeignKey("dbo.Cidade", "UFID", "dbo.UF");
            DropForeignKey("dbo.Cliente", "EnderecoID", "dbo.Endereco");
            DropForeignKey("dbo.Veiculo", "ClienteID", "dbo.Cliente");
            DropForeignKey("dbo.ClientesServicosUtilizados", "ServicoID", "dbo.Servico");
            DropForeignKey("dbo.ClientesServicosUtilizados", "ClienteID", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "RamoAtividadeID", "dbo.RamoAtividade");
            DropForeignKey("dbo.ClientesPostosFavoritos", "PostoID", "dbo.Posto");
            DropForeignKey("dbo.ClientesPostosFavoritos", "ClienteID", "dbo.Cliente");
            DropForeignKey("dbo.MudancaEstadoCliente", "ClienteID", "dbo.Cliente");
            DropForeignKey("dbo.ClientesMarcasPreferidas", "MarcaID", "dbo.Marca");
            DropForeignKey("dbo.ClientesMarcasPreferidas", "ClienteID", "dbo.Cliente");
            DropForeignKey("dbo.Contato", "ClienteID", "dbo.Cliente");
            DropForeignKey("dbo.Bairro", "CidadeID", "dbo.Cidade");
            DropIndex("dbo.ClientesServicosUtilizados", new[] { "ServicoID" });
            DropIndex("dbo.ClientesServicosUtilizados", new[] { "ClienteID" });
            DropIndex("dbo.ClientesPostosFavoritos", new[] { "PostoID" });
            DropIndex("dbo.ClientesPostosFavoritos", new[] { "ClienteID" });
            DropIndex("dbo.ClientesMarcasPreferidas", new[] { "MarcaID" });
            DropIndex("dbo.ClientesMarcasPreferidas", new[] { "ClienteID" });
            DropIndex("dbo.Usuario", "UNQ_LOGIN");
            DropIndex("dbo.Veiculo", new[] { "ClienteID" });
            DropIndex("dbo.MudancaEstadoCliente", new[] { "ClienteID" });
            DropIndex("dbo.Contato", new[] { "ClienteID" });
            DropIndex("dbo.Cliente", new[] { "RamoAtividadeID" });
            DropIndex("dbo.Cliente", new[] { "EnderecoID" });
            DropIndex("dbo.Endereco", new[] { "UFID" });
            DropIndex("dbo.Endereco", new[] { "CidadeID" });
            DropIndex("dbo.Endereco", new[] { "BairroID" });
            DropIndex("dbo.Endereco", "UNQ_CEP");
            DropIndex("dbo.Cidade", new[] { "UFID" });
            DropIndex("dbo.Bairro", new[] { "CidadeID" });
            DropTable("dbo.ClientesServicosUtilizados");
            DropTable("dbo.ClientesPostosFavoritos");
            DropTable("dbo.ClientesMarcasPreferidas");
            DropTable("dbo.Usuario");
            DropTable("dbo.UF");
            DropTable("dbo.Veiculo");
            DropTable("dbo.Servico");
            DropTable("dbo.RamoAtividade");
            DropTable("dbo.Posto");
            DropTable("dbo.MudancaEstadoCliente");
            DropTable("dbo.Marca");
            DropTable("dbo.Contato");
            DropTable("dbo.Cliente");
            DropTable("dbo.Endereco");
            DropTable("dbo.Cidade");
            DropTable("dbo.Bairro");
        }
    }
}
