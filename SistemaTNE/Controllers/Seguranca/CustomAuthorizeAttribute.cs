using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace SistemaTNE.Controllers.Seguranca
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {

                if (!String.IsNullOrEmpty(Roles))
                {
                    if (!CurrentUser.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Home", action = "AcessoNegado" }));

                       // base.OnAuthorization(filterContext); //returns to login url
                    }
                }

                if (!String.IsNullOrEmpty(Users))
                {
                    if (!Users.Contains(CurrentUser.UsuarioID.ToString()))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                       // base.OnAuthorization(filterContext); //returns to login url
                    }
                }
            }
           else
            {
                filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Home", action = "Autenticacao" }));
            }
        }
    }
}