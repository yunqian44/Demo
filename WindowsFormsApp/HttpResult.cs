using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp
{
    #region 统一的数据返回
    public class HttpResult
    {
        /// <summary>
        /// 本构造函数 默认为 处理成功
        /// </summary>
        public HttpResult()
        {
            this.Status = 1;
        }
        /// <summary>
        /// 本构造函数 默认为 处理成功，且将返回数据传入
        /// </summary>
        /// <param name="d">返回数据</param>
        public HttpResult(dynamic d)
        {
            this.Status = 1;
            this.Data = d;
        }
        /// <summary>
        /// 默认作为出现错误时使用；
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="msg">错误信息</param>
        public HttpResult(int status, string msg)
        {
            this.Status = status;
            this.Message = msg;
        }

        public int Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }

    /// <summary>
    /// Api返回数据格式
    /// </summary>
    public class HttpResult<T> : HttpResult where T : class
    {
        public HttpResult()
        {
            this.Status = 1;
        }
        public HttpResult(T d)
            : this()
        {
            this.data = d;
        }

        public HttpResult(int status, string msg)
        {
            this.Status = status;
            this.Message = msg;
        }

        public new T data { get; set; }
    }
    #endregion
}
