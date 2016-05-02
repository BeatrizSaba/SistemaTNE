using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaTNE.Models
{
    public class AltSenhaUsuarioModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} não pode conter mais de {1} caracteres")]
        [MinLength(6, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirmar senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; }
    }
}