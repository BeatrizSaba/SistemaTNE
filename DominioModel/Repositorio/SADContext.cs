
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using DominioModel.Entidades;
using System.Linq;

namespace DominioModel.Repositorio
{ 
    public partial class SADContext : DbContext
    {
        public SADContext()
            : base("name=SADContext")
        {

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

            modelBuilder.Entity<Usuario>().Property(e => e.Login)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UNQ_LOGIN")
                {
                    IsUnique = true
                }));

            modelBuilder.Entity<Cliente>().Property(e => e.DataCriacao).HasColumnType("date");
            modelBuilder.Entity<Cliente>().Property(e => e.DataModificacao).HasColumnType("date");
            modelBuilder.Entity<Cliente>().Property(e => e.FormaPagamentoUsada).IsOptional();
            modelBuilder.Entity<Cliente>().Property(e => e.FrequenciaVisitaPosto).IsOptional();
            modelBuilder.Entity<Cliente>().Property(e => e.RamoAtividadeID).IsOptional();

            modelBuilder.Entity<MudancaEstadoCliente>().HasKey(e => new { e.ClienteID, e.DataModificacao });
            modelBuilder.Entity<MudancaEstadoCliente>().Property(e => e.ClienteID).HasColumnOrder(0);
            modelBuilder.Entity<MudancaEstadoCliente>().Property(e => e.DataModificacao).HasColumnOrder(1);

            modelBuilder.Entity<MudancaEstadoCliente>().Property(e => e.ClienteID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Bairro>()
                .HasMany(e => e.Enderecos)
                .WithRequired(e => e.Bairros)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Cidade>()
                .HasMany(e => e.Bairros)
                .WithRequired(e => e.Cidades)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cidade>()
                .HasMany(e => e.Enderecos)
                .WithRequired(e => e.Cidades)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Contatos)
                .WithRequired(e => e.Clientes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Veiculos)
                .WithRequired(e => e.Clientes)
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
                .WithRequired(e => e.Enderecos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UF>()
                .HasMany(e => e.Cidades)
                .WithRequired(e => e.UFs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UF>()
                .HasMany(e => e.Enderecos)
                .WithRequired(e => e.UFs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Veiculo>()
                .Property(e => e.Placa)
                .IsFixedLength()
                .IsUnicode(false);
        }

    }
}
