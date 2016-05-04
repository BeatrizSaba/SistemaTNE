using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{

    public partial class Veiculo
    {
        public int VeiculoID { get; set; }
            
        public int ClienteID { get; set; }

        public string Modelo { get; set; }

        public string Placa { get; set; }

        public virtual Cliente Clientes { get; set; }
    }
}
