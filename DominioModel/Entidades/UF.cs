using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{

    public partial class UF
    {

        public int UFID { get; set; }

        public string Nome { get; set; }


        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
