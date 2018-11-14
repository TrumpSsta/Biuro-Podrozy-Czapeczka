using System.Web;
using System.Web.Mvc;

namespace BiuroPodrozyCzapeczka
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
