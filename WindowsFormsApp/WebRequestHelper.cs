using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace WindowsFormsApp
{
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
}
