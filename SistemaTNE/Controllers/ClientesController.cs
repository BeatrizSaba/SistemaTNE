using SistemaTNE.Controllers.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaTNE.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Cliente
        [CustomAuthorize(Roles = "Administrador,Gestor,Frentista")]
        public ActionResult NovoEditar()
        {
            return PartialView();
        }

        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult Lista()
        {
            return PartialView();
        }
    }
}