using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());//默认的异常错误处理异常过滤器

             //注册filter：校验Token过滤器
            // filters.Add(new TokenCheckFilterAttribute());
            //第三种filter：异常过滤器
            //filters.Add(new ApiErrorHandleAttribute());
            
        }
    }
}
