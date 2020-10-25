using System.Web;
using System.Web.Mvc;

namespace N_Tier.MiniApp.Presentation.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
