using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominioModel.Entidades
{

    public partial class MudancaEstadoCliente
    {
        public int ClienteID { get; set; }

        public DateTime DataModificacao { get; set; }


        public int EstadoAnterior { get; set; }

        public int EstadoNovo { get; set; }

        [StringLength(200)]
        public string Observacao { get; set; }

        public virtual Cliente Clientes { get; set; }
    }
}
