using SistemaTNE.Controllers.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaTNE.Controllers
{
    public class OLAPController : Controller
    {
        // GET: OLAP
        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult Consulta()
        {
            return PartialView();
        }
    }
}