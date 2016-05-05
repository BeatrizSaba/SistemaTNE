using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaTNE.Controllers.Seguranca
{
    public class WizardSecurity
    {
        public static void SignIn(Controller control, CustomPrincipalSerializeModel serializeModel)
        {
            /*
            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
            serializeModel.UserId = user.UserId;
            serializeModel.FirstName = user.FirstName;
            serializeModel.LastName = user.LastName;
            serializeModel.roles = roles;
            */

            string userData = JsonConvert.SerializeObject(serializeModel);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                     1,
                     serializeModel.UsuarioID.ToString(),
                     DateTime.Now,
                     DateTime.Now.AddMinutes(1),
                     false,
                     userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            control.Response.Cookies.Add(faCookie);
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public static void Application_PostAuthenticateRequest(HttpApplication app, Object sender, EventArgs e)
        {
            HttpCookie authCookie = app.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {

                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
                CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                newUser.UsuarioID = serializeModel.UsuarioID;
                newUser.Nome = serializeModel.Nome;
                newUser.Papel = serializeModel.Papel;

                HttpContext.Current.User = newUser;
            }

        }
    }
}