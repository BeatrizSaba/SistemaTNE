using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using DominioModel.Entidades;

namespace SistemaTNE.Controllers.Seguranca
{
    public class CustomPrincipal : IPrincipal
    {
        public const char ROLE_SEPARATOR = ',';

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            string[] roles = role.Split(ROLE_SEPARATOR);

            return (roles.Any( r => r.Contains(Papel.ToString())));
        }

        public CustomPrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }

        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public PapelUsuario Papel { get; set; }
    }

    public class CustomPrincipalSerializeModel
    {
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public PapelUsuario Papel { get; set; }
    }
}