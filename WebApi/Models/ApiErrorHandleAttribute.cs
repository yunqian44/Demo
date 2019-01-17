using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using ViewModel;

namespace WebApi.Models
{
    /// <summary>
    /// 错误拦截器
    /// </summary>
    public class ApiErrorHandleAttribute: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            base.OnException(filterContext);
            if (filterContext.Exception is RequestException)
            {
                var ex = filterContext.Exception as RequestException;
                var errorMessage = ex.ErrorMessage;
                var result = new HttpResult(ex.Code, errorMessage);
                //// 重新打包回传的讯息
                //filterContext.HttpContext.Response.ContentType = "application/json";
                //filterContext.HttpContext.Response.Write(JsonConvert.SerializeObject(result));
                //filterContext.ExceptionHandled = true;
                //filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                // 重新打包回传的讯息
                var res = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                var httpContent = new StringContent(JsonConvert.SerializeObject(result));
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                res.Content = httpContent;
                filterContext.Response = res;
                filterContext.Response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                //写日志文件
            }
        }

        //public override void OnException(HttpActionExecutedContext actionExecutedContext)
        //{
        //    base.OnException(actionExecutedContext);
        //    if (actionExecutedContext.Exception is RequestException)
        //    {
        //        var ex = actionExecutedContext.Exception as RequestException;
        //        var errorMessage = ex.ErrorMessage;
        //        var result = new ViewModel.HttpResult(ex.Code, errorMessage);
        //        // 重新打包回传的讯息
        //        var res = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
        //        var httpContent = new StringContent(JsonConvert.SerializeObject(result));
        //        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //        res.Content = httpContent;
        //        actionExecutedContext.Response = res;
        //        actionExecutedContext.Response.StatusCode = System.Net.HttpStatusCode.OK;
        //    }
        //    else
        //    {
        //        //写日志文件
        //    }
        //}
    }
}