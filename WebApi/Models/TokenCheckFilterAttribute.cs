using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.Models
{
    /// <summary>
    /// token验证拦截器
    /// </summary>
    public class TokenCheckFilterAttribute:ActionFilterAttribute, IActionFilter
    {
        /// <summary>
        /// 是否检验
        /// </summary>
        public bool IsCheck { get; set; }

        /// <summary>
        /// 在Action控制器之前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (IsCheck)
            {
                ////校验用户是否已经登陆
                //if (filterContext.HttpContext.Session["user"] == null)
                //{
                //    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                //}
                if (string.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Request.Headers["token"]))
                {
                    throw new RequestException(10001, "token缺失，请检查token是否存在！");
                }
                else {
                    if (System.Web.HttpContext.Current.Request.Headers["token"] != "yunqian")
                    {
                        throw new RequestException(10001, "token失效，请确认是否已在其他地方登录！");
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}