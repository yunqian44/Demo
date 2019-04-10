using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
 
    /// <summary>
    /// 测试控制器
    /// </summary>
    [TokenCheckFilterAttribute(IsCheck = false)]
    public class ValuesController : ApiController
    {

        // GET api/values/5
        /// <summary>
        /// 测试Get方法
        /// </summary>
        /// <param name="model">Teacher对象</param>
        /// <returns></returns>
        public string Get(DateTime? model)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// Post测试方法
        /// </summary>
        /// <param name="model">Teacher对象</param>
        /// <returns></returns>
        public string Post([FromBody]UserInfo model)
        {

            return string.Format("我叫{0},我是个{1}", model.Name, model.sex.Equals(0) ? "男的" : "女的");
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
