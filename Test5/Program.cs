using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Test5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01，百度AI识别
            var obj2= IdCardValidateService.GetIdCardInfo(@"http://aip.bdstatic.com/portal/dist/1547780921660/ai_images/technology/ocr-cards/idcard/demo-card-1.png");

            Console.WriteLine(JsonConvert.SerializeObject(obj2));
            Console.ReadKey();
            #endregion
        }
    }

    public class IdCardValidateService
    {
        private const string host = "https://aip.baidubce.com/rest/2.0/ocr/v1";
        private const string oauthhost = "https://aip.baidubce.com/oauth/2.0/token";

        private const string idCardvalidatehost = "https://aip.baidubce.com/rest/2.0/face/v3";

        private const string idCardValidate = "/idcard";

        private const string idCard = "/person/verify";
        private const string infopath = "/business_license";
        private const string appId = "xxxx";

        private const string grantType = "client_credentials";
        private const string apiKey = "xxxx";
        private const string secretkey = "xxx";

        #region 01，获取百度token+string GetBaidu_AccessToken(string imagePath)
        /// <summary>
        /// 获取百度token
        /// </summary>
        /// <returns></returns>
        public static HttpResult GetBaidu_AccessToken()
        {
            string url = oauthhost;

            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("grant_type", grantType);
            param.Add("client_id", apiKey);
            param.Add("client_secret", secretkey);


            var result = WebRequestHelper.WebPostRequest<JObject>(url, param);
            var accessToken = result["access_token"];
            var errorMsg = result["error"];
            if (accessToken != null)
            {
                return new HttpResult(accessToken.ToString());
            }
            else
            {
                return new HttpResult(0, errorMsg.ToString());
            }
        }
        #endregion

        #region 01，获取身份证信息+Person GetIdCardInfo(string imagePath)
        /// <summary>
        /// 获取身份证信息
        /// </summary>
        /// <param name="imagePath">图书路径</param>
        /// <returns></returns>
        public static HttpResult GetIdCardInfo(string imagePath)
        {

            var getTokenResult = IdCardValidateService.GetBaidu_AccessToken();
            if (getTokenResult.Status == 0)
            {
                return new HttpResult(0, getTokenResult.Message);
            }

            string url = host + idCardValidate;


            var request = HttpHelper.GetGetResponseEx(imagePath);
            var base64 = HttpHelper.GetResponseStream(request);


            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("id_card_side", "front");
            param.Add("image", HttpUtility.UrlEncode(base64.ToByteBase64()));
            param.Add("access_token", getTokenResult.Data);

            var result = WebRequestHelper.WebPostRequest<JObject>(url, param, false);

            var obj = result["words_result"];
            var errorMsg = result["error"];

            if (obj != null)
            {
                var dic = JsonConvert.DeserializeObject<IDictionary<string, object>>(obj.ToString());
                return new HttpResult(dic.ToEntity<IdCardInfo>());
            }
            else
            {
                return new HttpResult(0, errorMsg.ToString());
            }
        }
        #endregion

        #region 05，身份证信息验证+static VehicleLicenseModel IdCardValidate(string imagePath)
        /// <summary>
        /// 获取行驶证信息
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        public static bool IdCardValidate(string imagePath, string imageType, string idCardNumber, string name)
        {
            var getTokenResult = IdCardValidateService.GetBaidu_AccessToken();
            if (getTokenResult.Status == 0)
            {
                return false;
            }

            string url = idCardvalidatehost + idCard;


            var request = HttpHelper.GetGetResponseEx(imagePath);
            var base64 = HttpHelper.GetResponseStream(request);

            Dictionary<string, string> param = new Dictionary<string, string>();

            //param.Add("image", HttpUtility.UrlEncode(Convert.ToBase64String(base64)));
            param.Add("image", imagePath);
            param.Add("id_card_number", idCardNumber);
            param.Add("image_type", imageType);
            param.Add("name", name);
            param.Add("access_token", getTokenResult.Data);

            var result = WebRequestHelper.WebPostRequest<JObject>(url, param, false);

            var obj = result["result"];
            var errorMsg = result["error_msg"];
            if (obj != null)
            {
                var dic = JsonConvert.DeserializeObject<IDictionary<string, int>>(obj.ToString());
                if (dic.Keys.Contains("score"))
                {
                    int value = dic["score"];
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }


    public class WebRequestHelper
    {
        #region Get请求
        /// <summary>
        /// Get请求(https未做验证考虑)
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="param">参数列表(如果在url中已经追加参数则此值可为null或空字符)</param>
        /// <returns></returns>
        public static TResult WebGetRequest<TResult>(string url, Dictionary<string, string> param, Dictionary<string, string> headers = null) where TResult : class
        {
            HttpWebRequest webRequest = null;
            if (param == null || param.Count == 0)
            {
                webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            }
            else
            {
                url += "?";
                string paramStr = string.Empty;
                for (int i = 0; i < param.Count; i++)
                {
                    paramStr += param.ElementAt(i).Key + "=" + param.ElementAt(i).Value + "&";
                }
                url += paramStr.Substring(0, paramStr.LastIndexOf("&"));
                webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            }
            webRequest.Method = "GET";
            webRequest.Timeout = 1000000;
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    webRequest.Headers.Add(item.Key, item.Value);
                }
            }
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)webRequest.GetResponse();
            System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
            string strResult = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<TResult>(strResult);
        }
        #endregion

        #region POST请求
        /// <summary>
        /// POST请求(https未做验证考虑)
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="param">参数列表(如果在url中已经追加参数则此值可为null或空字符)</param>
        /// <returns></returns>
        public static TResult WebPostRequest<TResult>(string url, Dictionary<string, string> param, bool isJson = false, Dictionary<string, string> headers = null) where TResult : class
        {
            System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            //webRequest.KeepAlive = true;
            //webRequest.AllowAutoRedirect = true;
            webRequest.Method = "POST";
            string paramStr = string.Empty;
            if (isJson)
            {
                webRequest.ContentType = "application/json";
                paramStr = param.ElementAt(0).Value;
            }
            else
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";
                for (int i = 0; i < param.Count; i++)
                {
                    paramStr += param.ElementAt(i).Key + "=" + param.ElementAt(i).Value + "&";
                }
                paramStr = paramStr.Substring(0, paramStr.LastIndexOf("&"));
            }
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    webRequest.Headers.Add(item.Key, item.Value);
                }
            }
            //将URL编码后的字符串转化为字节
            byte[] byteArray = Encoding.UTF8.GetBytes(paramStr);
            //设置请求的 ContentLength 
            webRequest.ContentLength = byteArray.Length;
            //获得请 求流
            System.IO.Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            // 关闭请求流
            dataStream.Close();
            // 获得响应流
            System.Net.WebResponse response = webRequest.GetResponse();
            dataStream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
            //string cookie = response.Headers.Get("Set-Cookie");
            string str = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<TResult>(str);
        }
        #endregion

        #region PUT请求
        /// <summary>
        /// POST请求(https未做验证考虑)
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="param">参数列表(如果在url中已经追加参数则此值可为null或空字符)</param>
        /// <returns></returns>
        public static TResult WebPutRequest<TResult>(string url, Dictionary<string, string> param, Dictionary<string, string> headers = null) where TResult : class
        {
            System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            //webRequest.KeepAlive = true;
            //webRequest.AllowAutoRedirect = true;
            webRequest.Method = "PUT";
            //webRequest.Accept = "text/html, application/xhtml+xml, */*";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    webRequest.Headers.Add(item.Key, item.Value);
                }
            }
            string paramStr = string.Empty;
            for (int i = 0; i < param.Count; i++)
            {
                paramStr += param.ElementAt(i).Key + "=" + param.ElementAt(i).Value + "&";
            }
            //将URL编码后的字符串转化为字节
            byte[] byteArray = Encoding.UTF8.GetBytes(paramStr.Substring(0, paramStr.LastIndexOf("&")));
            //设置请求的 ContentLength 
            webRequest.ContentLength = byteArray.Length;
            //获得请 求流
            System.IO.Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            // 关闭请求流
            dataStream.Close();
            // 获得响应流
            System.Net.WebResponse response = webRequest.GetResponse();
            dataStream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
            //string cookie = response.Headers.Get("Set-Cookie");
            string str = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<TResult>(str);
        }
        #endregion
    }


    public class HttpHelper
    {
        /// <summary>
        /// 获取URL响应对象
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static WebResponse GetGetResponseEx(string url)
        {
            System.Net.HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.KeepAlive = true;
            WebResponse res = request.GetResponse();
            return res;
        }

        public static byte[] GetResponseStream(WebResponse response)
        {
            Stream smRes = response.GetResponseStream();
            byte[] resBuf = new byte[10240];
            int nReaded = 0;
            MemoryStream memSm = new MemoryStream();
            while ((nReaded = smRes.Read(resBuf, 0, 10240)) != 0)
            {
                memSm.Write(resBuf, 0, nReaded);
            }
            byte[] byResults = memSm.ToArray();
            memSm.Close();
            return byResults;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true)]
    public class EnitityMappingAttribute : Attribute
    {
        private string _className;
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        private string _propertyName;
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }
    }


    #region 身份证类
    [EnitityMapping(ClassName = "words_result")]
    public class IdCardInfo
    {
        private string _address;
        [EnitityMapping(PropertyName = "住址")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _idCard;
        [EnitityMapping(PropertyName = "公民身份号码")]
        public string IdCard
        {
            get { return _idCard; }
            set { _idCard = value; }
        }

        public string _name;
        [EnitityMapping(PropertyName = "姓名")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string _gender;
        [EnitityMapping(PropertyName = "性别")]
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string _nation;
        [EnitityMapping(PropertyName = "民族")]
        public string Nation
        {
            get { return _nation; }
            set { _nation = value; }
        }


        private string _birthday;
        [EnitityMapping(PropertyName = "出生")]
        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }


    }
    #endregion

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

    public static class StringHelper
    {
        public static string ToByteBase64(this byte[] buffer)
        {
            return Convert.ToBase64String(buffer);
        }
    }

    public static class DictionaryExtension
    {
        public static object ToEntity(this IDictionary<string, object> source, Type type)
        {
            var instance = Activator.CreateInstance(type);
            //取属性上的自定义特性
            foreach (PropertyInfo propInfo in type.GetProperties())
            {
                object[] objAttrs = propInfo.GetCustomAttributes(typeof(EnitityMappingAttribute), true);

                if (propInfo.CanWrite)
                {
                    if (objAttrs.Length > 0)
                    {
                        try
                        {
                            EnitityMappingAttribute attr = objAttrs[0] as EnitityMappingAttribute;
                            if (attr != null)
                            {
                                var val = (JObject)source[attr.PropertyName];
                                propInfo.SetValue(instance, Convert.ChangeType(val["words"], propInfo.PropertyType), null);
                                //listColumnName.Add(attr.PropertyName); //列名
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            return instance;
        }

        public static T ToEntity<T>(this IDictionary<string, object> source) where T : class, new()
        {
            return ToEntity(source, typeof(T)) as T;
        }
    }
}
