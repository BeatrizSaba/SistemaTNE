using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DominioModel.Entidades
{
    public partial class Bairro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bairro()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public int BairroID { get; set; }

        public string Nome { get; set; }

        public int CidadeID { get; set; }

        public virtual Cidade Cidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
