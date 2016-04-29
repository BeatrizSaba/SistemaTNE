using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{

    public partial class Marca
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Marca()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int MarcaID { get; set; }

        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
