using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaTNE.Controllers
{
    public class HomeController : Controller
    {
        private const string USUARIO = "usuario";

        public ActionResult Index()
        {
            ViewBag.Usuario = Session[USUARIO];
            return View();
        }

        public ActionResult Autenticacao()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Autenticacao(FormCollection formData)
        {
            if (formData[0].Equals("Administrador") || (formData[0].Equals("Gestor")))
            {
                Session[USUARIO] = formData[0];

                return RedirectToAction("Index");
            }
            else
                return View();
        }


        #region Default Actions
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion
    }
}