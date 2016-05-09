
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using DominioModel.Entidades;
using System.Linq;
using System.Collections.Generic;
using DominioModel.Repositorio.Abstrato;
using DominioModel.Repositorio.Concreto;

namespace DominioModel.Repositorio
{

    class SADContextInitializer : CreateDatabaseIfNotExists<SADContext>
    {
        protected override void Seed(SADContext context)
        {         
            List<Posto> postos = new List<Posto>();
            postos.Add(new Posto() { Nome = "Belo Vale" });
            postos.Add(new Posto() { Nome = "Pérola" });
            postos.Add(new Posto() { Nome = "Século XXI" });
            postos.Add(new Posto() { Nome = "Outros" });

            List<Marca> marcas = new List<Marca>();
            marcas.Add(new Marca() { Nome = "Ipiranga" });
            marcas.Add(new Marca() { Nome = "Petrobrás" });
            marcas.Add(new Marca() { Nome = "Outras" });

            List<Servico> servicos = new List<Servico>();
            servicos.Add(new Servico() { Descricao = "Abastecimento" });
            servicos.Add(new Servico() { Descricao = "Calibragem" });
            servicos.Add(new Servico() { Descricao = "Lavagem" });               
            servicos.Add(new Servico() { Descricao = "Loja de conveniência" });
            servicos.Add(new Servico() { Descricao = "Troca de óleo" });

            List<RamoAtividade> ramosAtiv = new List<RamoAtividade>();
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Alimentos e Bebidas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Arte e Antiguidades" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Artigos Religiosos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Assinaturas e Revistas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Automóveis e Veículos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Bebês e Cia" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Brindes / Materiais Promocionais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Brinquedos e Games" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Casa e Decoração" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Colecionáveis" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Compras Coletivas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Construção e Ferramentas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Cosméticos e Perfumaria" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Cursos e Educação" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Discos de Vinil" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Eletrodomésticos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Eletrônicos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Emissoras de Rádio" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Emissoras de Televisão" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Empregos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Empresas de Telemarketing" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Esporte e Lazer" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Flores, Cestas e Presentes" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Fotografia" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Igrejas / Templos / Instituições Religiosas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Indústria, Comércio e Negócios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Infláveis Promocionais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Informática" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Instrumentos Musicais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Joalheria" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Lazer" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Moda e Acessórios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Música Digital" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Negócios e Oportunidades" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Outros Serviços" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Papelaria e Escritório" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviço Advocaticios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Pet Shop" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Saúde" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviço de Distribuição de Jornais / Revistas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços Administrativos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços Artísticos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Abatedouros / Matadouros" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Aeroportos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Agências" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Aluguel / Locação" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Armazenagem" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Assessorias" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Assistência Técnica / Instalações" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Associações" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Bancos de Sangue" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Bibliotecas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Cartórios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Casas Lotéricas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Confecções" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Consórcios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Consultorias" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Cooperativas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Despachante" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Engenharia" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Estacionamentos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Estaleiros" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Exportação / Importação" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Geólogos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de joalheiros" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Leiloeiros" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de limpeza" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Loja de Conveniência" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Mão de Obra" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Órgão Públicos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Pesquisas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Portos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Saúde / Bem Estar" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Seguradoras" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Segurança" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Sinalização" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Sindicatos / Federações" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Traduções" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Transporte" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços de Utilidade Pública" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Agricultura / Pecuária / Piscicultura" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Alimentação" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Arte" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Cine / Foto / Som" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Comunicação" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Construção" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Ecologia / Meio Ambiente" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Eletroeletrônica / Metal Mecânica" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Festas / Eventos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Informática" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Internet" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Jóias / Relógios / Óticas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Telefonia" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços em Veículos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços Esotéricos / Místicos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços Financeiros" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços Funerários" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços Gerais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços Gráficos / Editoriais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços para Animais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços para Deficientes" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços para Escritórios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços para Roupas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Serviços Socias / Assistenciais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Sex Shop" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Shopping Centers" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Tabacaria" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Tarifas Bancárias" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Tarifas Telefônicas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Telefonia" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Turismo" });

            context.Postos.AddRange(postos);
            context.Marcas.AddRange(marcas);
            context.Servicos.AddRange(servicos);
            context.RamosAtividades.AddRange(ramosAtiv);

            context.SaveChanges();


            Usuario defaultAdmin = new Usuario()
            {
                Login = "SADAdmin",
                Senha = "sadadmin2016",
                Nome = "Administrador padrão",
                Papel = PapelUsuario.Administrador
            };
        
            IUsuariosRepositorio userRep = new UsuariosRepositorio(new SADContext());

            var admin = (from usr in userRep.Usuarios
                         where usr.Login.Equals(defaultAdmin.Login)
                         select usr).SingleOrDefault();


            if (admin == null)
                userRep.Inserir(defaultAdmin);


            

            base.Seed(context);
        }
    }

    public partial class SADContext : DbContext
    {
        public SADContext()
            : base("name=SADContext")
        {
            Database.SetInitializer(new SADContextInitializer());

            if (!Database.Exists())
                Database.Initialize(true);
        }

        public virtual DbSet<Bairro> Bairros { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Posto> Postos { get; set; }
        public virtual DbSet<Servico> Servicos { get; set; }
        public virtual DbSet<UF> UFs { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Contato> Contatos { get; set; }
        public virtual DbSet<MudancaEstadoCliente> MudancaEstadoClientes { get; set; }
        public virtual DbSet<Veiculo> Veiculos { get; set; }
        public virtual DbSet<RamoAtividade> RamosAtividades { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Usuario>().Property(e => e.Login).HasMaxLength(30);
            modelBuilder.Entity<Usuario>().Property(e => e.Senha).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(e => e.Login)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UNQ_LOGIN")
                {
                    IsUnique = true
                }));

            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Cliente>().Property(e => e.Nome).HasMaxLength(70);
            modelBuilder.Entity<Cliente>().Property(e => e.Residencia).HasMaxLength(20);
            modelBuilder.Entity<Cliente>().Property(e => e.DataCriacao).HasColumnType("date");
            modelBuilder.Entity<Cliente>().Property(e => e.DataModificacao).HasColumnType("date");
            modelBuilder.Entity<Cliente>().Property(e => e.FormaPagamentoUsada).IsOptional();
            modelBuilder.Entity<Cliente>().Property(e => e.FrequenciaVisitaPosto).IsOptional();
            modelBuilder.Entity<Cliente>().Property(e => e.RamoAtividadeID).IsOptional();

            modelBuilder.Entity<MudancaEstadoCliente>().ToTable("MudancaEstadoClientes");
            modelBuilder.Entity<MudancaEstadoCliente>().HasKey(e => new { e.ClienteID, e.DataModificacao });
            modelBuilder.Entity<MudancaEstadoCliente>().Property(e => e.ClienteID).HasColumnOrder(0);
            modelBuilder.Entity<MudancaEstadoCliente>().Property(e => e.DataModificacao).HasColumnOrder(1);
            modelBuilder.Entity<MudancaEstadoCliente>().Property(e => e.Observacao).HasMaxLength(200).IsOptional();
            modelBuilder.Entity<MudancaEstadoCliente>().Property(e => e.ClienteID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<RamoAtividade>().ToTable("RamosAtividade");
            modelBuilder.Entity<RamoAtividade>().Property(e => e.Descricao).HasMaxLength(50);

            modelBuilder.Entity<Endereco>().ToTable("Enderecos");
            modelBuilder.Entity<Endereco>().Property(e => e.CEP).HasMaxLength(8).IsFixedLength();
            modelBuilder.Entity<Endereco>().Property(e => e.Logradouro).HasMaxLength(60);

            modelBuilder.Entity<Bairro>().ToTable("Bairros");
            modelBuilder.Entity<Bairro>().Property(e => e.BairroID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Bairro>().Property(e => e.Nome).HasMaxLength(50);

            modelBuilder.Entity<Cidade>().ToTable("Cidades");
            modelBuilder.Entity<Cidade>().Property(e => e.Nome).HasMaxLength(50);

            modelBuilder.Entity<UF>().ToTable("Estados");
            modelBuilder.Entity<UF>().Property(e => e.Nome).HasMaxLength(50);

            modelBuilder.Entity<Contato>().ToTable("Contatos");
            modelBuilder.Entity<Contato>().Property(e => e.Nome).HasMaxLength(40).IsOptional();
            modelBuilder.Entity<Contato>().Property(e => e.Telefone).HasMaxLength(14);

            modelBuilder.Entity<Veiculo>().ToTable("Veiculos");
            modelBuilder.Entity<Veiculo>().Property(e => e.Modelo).HasMaxLength(30).IsOptional();
            modelBuilder.Entity<Veiculo>().Property(e => e.Placa).HasMaxLength(7).IsFixedLength().IsOptional() ;

            modelBuilder.Entity<Marca>().ToTable("Marcas");
            modelBuilder.Entity<Marca>().Property(e => e.Nome).HasMaxLength(40);

            modelBuilder.Entity<Posto>().ToTable("Postos");
            modelBuilder.Entity<Posto>().Property(e => e.Nome).HasMaxLength(50);

            modelBuilder.Entity<Servico>().ToTable("servicos");
            modelBuilder.Entity<Servico>().Property(e => e.Descricao).HasMaxLength(40);


            modelBuilder.Entity<Bairro>()
                .Property(e => e.Nome).HasColumnAnnotation("index",
                new IndexAnnotation(
                    new IndexAttribute("UNQ_BAIRRO_NOME") { IsUnique = true }));


            modelBuilder.Entity<Cidade>().Property(e => e.Nome).HasColumnAnnotation("Index",
                new IndexAnnotation(
                    new IndexAttribute("UNQ_CIDADE_NOME") { IsUnique = true }));

            modelBuilder.Entity<UF>().Property(e => e.Nome).HasColumnAnnotation("Index",
                new IndexAnnotation(
                    new IndexAttribute("UNQ_UF_NOME") { IsUnique = true }));


            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Contatos)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Veiculos)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Marcas)
                .WithMany(e => e.Clientes)
                .Map(m => m.ToTable("ClientesMarcasPreferidas").MapLeftKey("ClienteID").MapRightKey("MarcaID"));

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Postos)
                .WithMany(e => e.Clientes)
                .Map(m => m.ToTable("ClientesPostosFavoritos").MapLeftKey("ClienteID").MapRightKey("PostoID"));

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Servicos)
                .WithMany(e => e.Clientes)
                .Map(m => m.ToTable("ClientesServicosUtilizados").MapLeftKey("ClienteID").MapRightKey("ServicoID"));

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CEP)
                .IsFixedLength()
                .IsUnicode(false)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UNQ_CEP") { IsUnique = true }));

            modelBuilder.Entity<Endereco>()
                .HasMany(e => e.Clientes)
                .WithRequired(e => e.Endereco)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Endereco>()
                .HasRequired(e => e.Bairro)
                .WithMany(e => e.Enderecos);

            modelBuilder.Entity<Endereco>()
                .HasRequired(e => e.Cidade)
                .WithMany(e => e.Enderecos);

            modelBuilder.Entity<Endereco>()
                .HasRequired(e => e.UF)
                .WithMany(e => e.Enderecos);


            modelBuilder.Entity<Veiculo>()
                .Property(e => e.Placa)
                .IsFixedLength()
                .IsUnicode(false);
        }

    }
}
