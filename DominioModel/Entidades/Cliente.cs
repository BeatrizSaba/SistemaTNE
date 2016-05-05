using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominioModel.Entidades
{

    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Contatos = new HashSet<Contato>();
            Veiculos = new HashSet<Veiculo>();
            Marcas = new HashSet<Marca>();
            Postos = new HashSet<Posto>();
            Servicos = new HashSet<Servico>();
        }

        public int ClienteID { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataModificacao { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

        public EstadoCliente Estado { get; set; }

        public string Residencia { get; set; }

        public int EnderecoID { get; set; }

        public FrequenciaCompra FrequenciaVisitaPosto { get; set; }

        public FormaPagamento FormaPagamentoUsada { get; set; }

        public int? RamoAtividadeID { get; set; }

        public virtual RamoAtividade RamoAtividade { get; set; }

        public virtual Endereco Endereco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contato> Contatos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Veiculo> Veiculos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MudancaEstadoCliente> MudancasEstado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Marca> Marcas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posto> Postos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Servico> Servicos { get; set; }
    }
}
