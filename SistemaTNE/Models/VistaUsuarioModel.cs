using DominioModel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DominioModel.Utils;
using System.ComponentModel.DataAnnotations;

namespace SistemaTNE.Models
{
    public class VistaUsuarioModel
    {
        public int UsuarioID { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Papel { get; set; }

        public string Bloqueado { get; set; }
    }
}