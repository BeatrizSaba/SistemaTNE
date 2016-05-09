
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
            postos.Add(new Posto() { Nome = "P�rola" });
            postos.Add(new Posto() { Nome = "S�culo XXI" });
            postos.Add(new Posto() { Nome = "Outros" });

            List<Marca> marcas = new List<Marca>();
            marcas.Add(new Marca() { Nome = "Ipiranga" });
            marcas.Add(new Marca() { Nome = "Petrobr�s" });
            marcas.Add(new Marca() { Nome = "Outras" });

            List<Servico> servicos = new List<Servico>();
            servicos.Add(new Servico() { Descricao = "Abastecimento" });
            servicos.Add(new Servico() { Descricao = "Calibragem" });
            servicos.Add(new Servico() { Descricao = "Lavagem" });               
            servicos.Add(new Servico() { Descricao = "Loja de conveni�ncia" });
            servicos.Add(new Servico() { Descricao = "Troca de �leo" });

            List<RamoAtividade> ramosAtiv = new List<RamoAtividade>();
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Alimentos e Bebidas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Arte e Antiguidades" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Artigos Religiosos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Assinaturas e Revistas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Autom�veis e Ve�culos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Beb�s e Cia" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Brindes / Materiais Promocionais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Brinquedos e Games" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Casa e Decora��o" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Colecion�veis" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Compras Coletivas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Constru��o e Ferramentas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Cosm�ticos e Perfumaria" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Cursos e Educa��o" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Discos de Vinil" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Eletrodom�sticos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Eletr�nicos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Emissoras de R�dio" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Emissoras de Televis�o" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Empregos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Empresas de Telemarketing" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Esporte e Lazer" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Flores, Cestas e Presentes" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Fotografia" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Igrejas / Templos / Institui��es Religiosas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Ind�stria, Com�rcio e Neg�cios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Infl�veis Promocionais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Inform�tica" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Instrumentos Musicais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Joalheria" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Lazer" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Moda e Acess�rios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "M�sica Digital" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Neg�cios e Oportunidades" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Outros Servi�os" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Papelaria e Escrit�rio" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�o Advocaticios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Pet Shop" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Sa�de" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�o de Distribui��o de Jornais / Revistas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os Administrativos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os Art�sticos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Abatedouros / Matadouros" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Aeroportos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Ag�ncias" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Aluguel / Loca��o" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Armazenagem" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Assessorias" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Assist�ncia T�cnica / Instala��es" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Associa��es" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Bancos de Sangue" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Bibliotecas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Cart�rios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Casas Lot�ricas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Confec��es" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Cons�rcios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Consultorias" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Cooperativas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Despachante" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Engenharia" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Estacionamentos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Estaleiros" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Exporta��o / Importa��o" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Ge�logos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de joalheiros" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Leiloeiros" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de limpeza" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Loja de Conveni�ncia" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de M�o de Obra" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de �rg�o P�blicos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Pesquisas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Portos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Sa�de / Bem Estar" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Seguradoras" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Seguran�a" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Sinaliza��o" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Sindicatos / Federa��es" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Tradu��es" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Transporte" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os de Utilidade P�blica" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Agricultura / Pecu�ria / Piscicultura" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Alimenta��o" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Arte" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Cine / Foto / Som" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Comunica��o" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Constru��o" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Ecologia / Meio Ambiente" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Eletroeletr�nica / Metal Mec�nica" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Festas / Eventos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Inform�tica" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Internet" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em J�ias / Rel�gios / �ticas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Telefonia" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os em Ve�culos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os Esot�ricos / M�sticos" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os Financeiros" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os Funer�rios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os Gerais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os Gr�ficos / Editoriais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os para Animais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os para Deficientes" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os para Escrit�rios" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os para Roupas" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Servi�os Socias / Assistenciais" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Sex Shop" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Shopping Centers" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Tabacaria" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Tarifas Banc�rias" });
            ramosAtiv.Add(new RamoAtividade() { Descricao = "Tarifas Telef�nicas" });
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
                Nome = "Administrador padr�o",
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
