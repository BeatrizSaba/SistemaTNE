using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{

    public partial class Veiculo
    {
        public int VeiculoID { get; set; }
            
        public int ClienteID { get; set; }

        [StringLength(30)]
        public string Modelo { get; set; }

        [StringLength(7)]
        public string Placa { get; set; }

        public virtual Cliente Clientes { get; set; }
    }
}
