using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Models.ViewModel;

namespace WebApi.Controllers
{
    [TokenCheckFilterAttribute(IsCheck = false)]
    [ApiErrorHandleAttribute]
    public class Values1Controller : ApiController
    {
        // GET api/values
        /// <summary>
        /// 测试Get方法
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// 测试Get方法
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [TokenCheckFilterAttribute(IsCheck = true)]
        public string Get(UserInfo model)
        {
            return "value";
        }

        //// POST api/values
        ///// <summary>
        ///// Post测试方法
        ///// </summary>
        ///// <param name="model">Teacher对象</param>
        ///// <returns></returns>
        //[TokenCheckFilterAttribute(IsCheck = false)]
        //public string Post([FromBody]Teacher model,string token,string vc)
        //{
        //    return "我叫李四,我是个男生";
        //}


        //// POST api/values
        ///// <summary>
        ///// Post测试方法
        ///// </summary>
        ///// <param name="model">Teacher对象</param>
        ///// <returns></returns>
        //[TokenCheckFilterAttribute(IsCheck = false)]
        //public string Post([FromBody]LoadingPlantReq model, string token, string vc)
        //{
        //    return "我叫李四,我是个男生";
        //}

        // POST api/values
        /// <summary>
        /// Post测试方法
        /// </summary>
        /// <param name="model">Teacher对象</param>
        /// <returns></returns>
        [TokenCheckFilterAttribute(IsCheck = false)]
        [AntiSqlInjectAttribute]
        public string Post([FromBody]UserInfo model)
        {
            return "我叫李四,我是个男生";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
