using DominioModel.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaTNE.Models
{
    public class ClienteEstadoModel
    {
        [Required]
        public int ClienteID { get; set; }

        [Display(Name = "Estado")]
        [Required (ErrorMessage = "Selecione um valor válido para {0}")]
        public EstadoCliente Estado { get; set; }

        [Display(Name = "Observação")]
        [MaxLength(200, ErrorMessage = "O campo {0} não pode conter mais do que {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Observacao { get; set; }
    }
}