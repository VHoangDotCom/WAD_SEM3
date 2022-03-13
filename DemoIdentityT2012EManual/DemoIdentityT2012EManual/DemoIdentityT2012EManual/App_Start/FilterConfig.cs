using System.Web;
using System.Web.Mvc;

namespace DemoIdentityT2012EManual
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
