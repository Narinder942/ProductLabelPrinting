using ProductLabelPrinting.Models.Models;
using System.Web;

namespace ProductLabelPrinting.Web.Helpers
{
    public class SessionHelper
    {
        public const string UserDetail = "UserDetail";

        public static int GetUserId()
        {
            int userId = 0;

            if (HttpContext.Current.Session[SessionHelper.UserDetail] != null)
            {
                return (HttpContext.Current.Session[SessionHelper.UserDetail] as EmployeeModel).Id;

            }
            return userId;
        }

        public static string GetUserRoleName()
        {
            if (HttpContext.Current.Session[SessionHelper.UserDetail] != null)
            {
                return (HttpContext.Current.Session[SessionHelper.UserDetail] as EmployeeModel).Role;

            }
            return "";
        }

    }
}