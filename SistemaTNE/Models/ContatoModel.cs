﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaTNE.Models
{
    public class ContatoModel
    {       
        public int ContatoID { get; set; }

        [StringLength(40, ErrorMessage = "O campo {0} não poder conter mais do que {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigátorio")]
        [StringLength(11 , ErrorMessage = "O campo {0} não poder conter mais do que {1} caracteres")]
        [MinLength(10, ErrorMessage = "O Telefone informado não é válido.")]
        public string Telefone { get; set; }
    }
}