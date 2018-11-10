using ApiResult.Infrastructure;
using System.Web;
using System.Web.Mvc;

namespace ApiResult
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorAttribute());
        }
    }
}
