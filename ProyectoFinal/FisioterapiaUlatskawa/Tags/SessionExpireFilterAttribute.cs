using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FisioterapiaUlatskawa.Tags
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (SessionHelper.ExistUserInSession())
            {
                // Valida la información que se encuentra en la sesión.
                if (HttpContext.Current.Session["userID"] == null)
                {
                    // Si la información es nula, redireccionar a la página de error u otra página deseada.
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Login",
                        action = "TimeoutRedirect"
                    }));
                }
            }
            else
            {
                // Si la Session expiró, redireccionar a la página de error u otra página deseada.
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "TimeoutRedirect"
                }));
            }
        }
    }
}