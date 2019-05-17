using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Models
{
    public class AntiSqlInjectAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionParameters = filterContext.ActionDescriptor.GetParameters();
            foreach (var p in actionParameters)
            {
                if (p.ParameterType == typeof(string))
                {
                    if (filterContext.ActionParameters[p.ParameterName] != null)
                    {
                        var t = 1;
                    }
                }
            }
        }
    }
}