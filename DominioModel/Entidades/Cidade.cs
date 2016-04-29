using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{

    public partial class Cidade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cidade()
        {
            Bairros = new HashSet<Bairro>();
            Enderecos = new HashSet<Endereco>();
        }

        public int CidadeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public int UFID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bairro> Bairros { get; set; }

        public virtual UF UFs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
