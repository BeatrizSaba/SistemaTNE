using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{

    public partial class Cidade
    {

        public int CidadeID { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
