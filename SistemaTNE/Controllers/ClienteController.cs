using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaTNE.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult NovoEditar()
        {
            return PartialView();
        }

        public ActionResult Lista()
        {
            return PartialView();
        }
    }
}