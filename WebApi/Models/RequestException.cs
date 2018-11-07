using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    /// <summary>
    /// 请求异常Model
    /// </summary>
    public class RequestException:Exception
    {
        public RequestException(string msg)
        {
            _ErrorMessage = msg;
        }

        public RequestException(int code, string msg)
        {
            _ErrorMessage = msg;
            _Code = code;
        }

        private string _ErrorMessage;
        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
        }

        private int _Code;
        public int Code {
            get { return _Code; }
        }
    }
}