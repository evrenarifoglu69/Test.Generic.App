using System.Web;
using System.Web.Mvc;
using Test.Generic.App.Filter;

namespace Test.Generic.App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggingFilterAttribute());
        }
    }
}
