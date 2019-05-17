using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAppTest.ApiControllers
{
    public class ValuesController1 : ApiController
    {
        // GET api/<controller>
        /// <summary>
        /// Get方法获取全部数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        /// <summary>
        /// Get方法 获取单个数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        /// <summary>
        /// Post方法 新增数据
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Put方法 修改数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// 删除 删除单个数据
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
}