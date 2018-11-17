using System.Web;
using System.Web.Mvc;

namespace WEB_APP_SCHOOL_NET
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
