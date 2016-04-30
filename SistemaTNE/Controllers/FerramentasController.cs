﻿using SistemaTNE.Controllers.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaTNE.Controllers
{
    public class FerramentasController : Controller
    {
        // GET: Ferramentas
        [CustomAuthorize(Roles = "Administrador")]
        public ActionResult ImportarDados()
        {
            return PartialView();
        }
    }
}