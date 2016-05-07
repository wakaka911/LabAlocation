using System.Web;
using System.Web.Mvc;

namespace LabAlocation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new AuthorizeAttribute());//所有controller添加验证
            filters.Add(new HandleErrorAttribute());
        }
    }
}