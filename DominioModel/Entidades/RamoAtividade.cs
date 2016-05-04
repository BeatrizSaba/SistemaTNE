using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{
    public class RamoAtividade
    {
        public int RamoAtividadeID { get; set; }

        public string Descricao { get; set; }


        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
