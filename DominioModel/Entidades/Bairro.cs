using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DominioModel.Entidades
{
    public partial class Bairro
    {
        public int BairroID { get; set; }

        public string Nome { get; set; }


        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
