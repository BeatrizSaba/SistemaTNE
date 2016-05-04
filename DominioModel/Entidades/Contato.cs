using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{

    public partial class Contato
    {
        public int ContatoID { get; set; }

        public int ClienteID { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public virtual Cliente Clientes { get; set; }
    }
}
