using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{

    public partial class Endereco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Endereco()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int EnderecoID { get; set; }

        [Required]
        [StringLength(8)]
        public string CEP { get; set; }

        [Required]
        [StringLength(60)]
        public string Logradouro { get; set; }

        public int BairroID { get; set; }

        public int CidadeID { get; set; }

        public int UFID { get; set; }

        public virtual Bairro Bairros { get; set; }

        public virtual Cidade Cidades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }

        public virtual UF UFs { get; set; }
    }
}
