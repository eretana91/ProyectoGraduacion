using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FisioterapiaUlatskawa.Tags
{
    public class SessionHelper
    {
        public static bool ExistUserInSession()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static void DestroyUserSession()
        {
            WipeCookies();
            FormsAuthentication.SignOut();
        }

        public static string GetUser()
        {
            string userData = "";

            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                //  HttpCookie cookie = HttpContext.Current.Response.Cookies.Get(".ASPXAUTH");
                //var ticket = FormsAuthentication.Decrypt(cookie.Value);

                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (ticket != null)
                {
                    userData = ticket.UserData;
                }
            }

            return userData;

        }

        public static void AddUserToSession(int pidEmpresa, string pidUsuario)
        {
            //WipeCookies();

            string key = ":Ekey:" + pidEmpresa + ":Ukey:" + pidUsuario + ":end:";

            HttpCookie cookie = FormsAuthentication.GetAuthCookie(pidUsuario, true);

            cookie.Name = FormsAuthentication.FormsCookieName;
            cookie.Expires = DateTime.Now.AddHours(1);

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newticket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, key, ticket.CookiePath);

            cookie.Value = FormsAuthentication.Encrypt(newticket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        // Funcion para Limpiar los datos de autenticacion de las cookies del navegador
        public static void WipeCookies()
        {
            //HttpContext.Current.Response.Cookies.Remove(".ASPXAUTH");

            List<HttpCookie> cookies = new List<HttpCookie>();
            for (int i = 0; i < HttpContext.Current.Request.Cookies.Count; i++)
            {
                var cookie = new HttpCookie(HttpContext.Current.Request.Cookies[i].Name);
                cookies.Add(cookie);
            }

            foreach (HttpCookie cookie1 in cookies)
            {
                cookie1.Expires = DateTime.Now.AddDays(-1);
                cookie1.Value = string.Empty;
                HttpContext.Current.Response.Cookies.Add(cookie1);
            }
        }
    }
}