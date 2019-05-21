using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        [HttpGet]
        [MyLoginCheckFilterAttribute(IsCheck = true)]
        public ActionResult Index([System.Web.Http.FromUri]UserInfo model)
        {
            return View();
            //return Json(new { },JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [MyLoginCheckFilterAttribute(IsCheck = true)]
        public JsonResult Test([System.Web.Http.FromUri]UserInfo model,string Name)
        {
            return Json(new {Data="你好" }, JsonRequestBehavior.AllowGet);
        }
    }
}