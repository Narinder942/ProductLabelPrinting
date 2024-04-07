using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace ProductLabelPrinting.Web.Helpers
{
    public class CustomAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if ((filterContext.HttpContext.Session[SessionHelper.UserDetail]) == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                     { "controller", "Account" },
                     { "action", "Login" },
                     { "area", "" },

                });
            }
        }
    }
}