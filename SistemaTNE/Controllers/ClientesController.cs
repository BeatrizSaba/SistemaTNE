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