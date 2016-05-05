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

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public int BairroID { get; set; }

        public int CidadeID { get; set; }

        public int UFID { get; set; }

        public virtual Bairro Bairro { get; set; }

        public virtual Cidade Cidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }

        public virtual UF UF { get; set; }
    }
}
