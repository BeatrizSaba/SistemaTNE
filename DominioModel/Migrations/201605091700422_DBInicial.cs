namespace DominioModel.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class DBInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bairros",
                c => new
                    {
                        BairroID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "index",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: UNQ_BAIRRO_NOME, IsUnique: True }")
                                },
                            }),
                    })
                .PrimaryKey(t => t.BairroID);
            
            CreateTable(
                "dbo.Enderecos",
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
                .ForeignKey("dbo.Bairros", t => t.BairroID, cascadeDelete: true)
                .ForeignKey("dbo.Cidades", t => t.CidadeID, cascadeDelete: true)
                .ForeignKey("dbo.Estados", t => t.UFID, cascadeDelete: true)
                .Index(t => t.CEP, unique: true, name: "UNQ_CEP")
                .Index(t => t.BairroID)
                .Index(t => t.CidadeID)
                .Index(t => t.UFID);
            
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        CidadeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.CidadeID)
                .Index(t => t.Nome, unique: true, name: "UNQ_CIDADE_NOME");
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        DataCriacao = c.DateTime(nullable: false, storeType: "date"),
                        DataModificacao = c.DateTime(nullable: false, storeType: "date"),
                        Nome = c.String(nullable: false, maxLength: 70),
                        DataNascimento = c.DateTime(nullable: false),
                        TipoPessoa = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Residencia = c.String(nullable: false, maxLength: 20),
                        EnderecoID = c.Int(nullable: false),
                        FrequenciaVisitaPosto = c.Int(),
                        FormaPagamentoUsada = c.Int(),
                        RamoAtividadeID = c.Int(),
                    })
                .PrimaryKey(t => t.ClienteID)
                .ForeignKey("dbo.RamosAtividade", t => t.RamoAtividadeID)
                .ForeignKey("dbo.Enderecos", t => t.EnderecoID)
                .Index(t => t.EnderecoID)
                .Index(t => t.RamoAtividadeID);
            
            CreateTable(
                "dbo.Contatos",
                c => new
                    {
                        ContatoID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        Nome = c.String(maxLength: 40),
                        Telefone = c.String(nullable: false, maxLength: 14),
                    })
                .PrimaryKey(t => t.ContatoID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        MarcaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.MarcaID);
            
            CreateTable(
                "dbo.MudancaEstadoClientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false),
                        DataModificacao = c.DateTime(nullable: false),
                        EstadoAnterior = c.Int(nullable: false),
                        EstadoNovo = c.Int(nullable: false),
                        Observacao = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => new { t.ClienteID, t.DataModificacao })
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.Postos",
                c => new
                    {
                        PostoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PostoID);
            
            CreateTable(
                "dbo.RamosAtividade",
                c => new
                    {
                        RamoAtividadeID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RamoAtividadeID);
            
            CreateTable(
                "dbo.servicos",
                c => new
                    {
                        ServicoID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ServicoID);
            
            CreateTable(
                "dbo.Veiculos",
                c => new
                    {
                        VeiculoID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        Modelo = c.String(maxLength: 30),
                        Placa = c.String(maxLength: 7, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.VeiculoID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID)
                .Index(t => t.ClienteID);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        UFID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.UFID)
                .Index(t => t.Nome, unique: true, name: "UNQ_UF_NOME");
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 30),
                        Senha = c.String(nullable: false, maxLength: 60),
                        Nome = c.String(nullable: false, maxLength: 20),
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
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Marcas", t => t.MarcaID, cascadeDelete: true)
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
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Postos", t => t.PostoID, cascadeDelete: true)
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
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.servicos", t => t.ServicoID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.ServicoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enderecos", "UFID", "dbo.Estados");
            DropForeignKey("dbo.Clientes", "EnderecoID", "dbo.Enderecos");
            DropForeignKey("dbo.Veiculos", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.ClientesServicosUtilizados", "ServicoID", "dbo.servicos");
            DropForeignKey("dbo.ClientesServicosUtilizados", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "RamoAtividadeID", "dbo.RamosAtividade");
            DropForeignKey("dbo.ClientesPostosFavoritos", "PostoID", "dbo.Postos");
            DropForeignKey("dbo.ClientesPostosFavoritos", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.MudancaEstadoClientes", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.ClientesMarcasPreferidas", "MarcaID", "dbo.Marcas");
            DropForeignKey("dbo.ClientesMarcasPreferidas", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Contatos", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Enderecos", "CidadeID", "dbo.Cidades");
            DropForeignKey("dbo.Enderecos", "BairroID", "dbo.Bairros");
            DropIndex("dbo.ClientesServicosUtilizados", new[] { "ServicoID" });
            DropIndex("dbo.ClientesServicosUtilizados", new[] { "ClienteID" });
            DropIndex("dbo.ClientesPostosFavoritos", new[] { "PostoID" });
            DropIndex("dbo.ClientesPostosFavoritos", new[] { "ClienteID" });
            DropIndex("dbo.ClientesMarcasPreferidas", new[] { "MarcaID" });
            DropIndex("dbo.ClientesMarcasPreferidas", new[] { "ClienteID" });
            DropIndex("dbo.Usuarios", "UNQ_LOGIN");
            DropIndex("dbo.Estados", "UNQ_UF_NOME");
            DropIndex("dbo.Veiculos", new[] { "ClienteID" });
            DropIndex("dbo.MudancaEstadoClientes", new[] { "ClienteID" });
            DropIndex("dbo.Contatos", new[] { "ClienteID" });
            DropIndex("dbo.Clientes", new[] { "RamoAtividadeID" });
            DropIndex("dbo.Clientes", new[] { "EnderecoID" });
            DropIndex("dbo.Cidades", "UNQ_CIDADE_NOME");
            DropIndex("dbo.Enderecos", new[] { "UFID" });
            DropIndex("dbo.Enderecos", new[] { "CidadeID" });
            DropIndex("dbo.Enderecos", new[] { "BairroID" });
            DropIndex("dbo.Enderecos", "UNQ_CEP");
            DropTable("dbo.ClientesServicosUtilizados");
            DropTable("dbo.ClientesPostosFavoritos");
            DropTable("dbo.ClientesMarcasPreferidas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Estados");
            DropTable("dbo.Veiculos");
            DropTable("dbo.servicos");
            DropTable("dbo.RamosAtividade");
            DropTable("dbo.Postos");
            DropTable("dbo.MudancaEstadoClientes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Contatos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Cidades");
            DropTable("dbo.Enderecos");
            DropTable("dbo.Bairros",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Nome",
                        new Dictionary<string, object>
                        {
                            { "index", "IndexAnnotation: { Name: UNQ_BAIRRO_NOME, IsUnique: True }" },
                        }
                    },
                });
        }
    }
}
