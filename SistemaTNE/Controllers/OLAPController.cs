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
        public ActionResult Consulta()
        {
            return PartialView();
        }
    }
}