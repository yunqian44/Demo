using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [TokenCheckFilterAttribute(IsCheck = false)]
    public class Values1Controller : ApiController
    {
        // GET api/values
        /// <summary>
        /// 测试Get方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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
        [HttpGet]
        [TokenCheckFilterAttribute(IsCheck = true)]
        public string Get(int id)
        {
            return "value" + id;
        }

        // POST api/values
        /// <summary>
        /// Post测试方法
        /// </summary>
        /// <param name="model">Teacher对象</param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheckFilterAttribute(IsCheck = true)]
        public string Post([FromBody]Teacher model)
        {
            return "我叫李四,我是个男生";
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
