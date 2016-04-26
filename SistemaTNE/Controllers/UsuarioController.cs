using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaTNE.Controllers
{
    public class UsuarioController : Controller
    {
    
        public ActionResult Novo()
        {
            return PartialView();
        }

        public ActionResult Lista()
        {
            return PartialView();
        }
    }
}