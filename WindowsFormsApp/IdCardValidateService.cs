using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WindowsFormsApp
{
    public class IdCardValidateService
    {
        private const string host = "https://aip.baidubce.com/rest/2.0/ocr/v1";
        private const string oauthhost = "https://aip.baidubce.com/oauth/2.0/token";

        private const string idCardvalidatehost = "https://aip.baidubce.com/rest/2.0/face/v3";

        private const string idCardValidate = "/idcard";

        private const string idCard = "/person/verify";
        private const string infopath = "/business_license";
        private const string appId = "15441403";

        private const string grantType = "client_credentials";
        private const string apiKey = "aTNBKm19tAzTmQUf1G5lpYBk";
        private const string secretkey = "NxhANErndxGXWbsqWEYbRyv4DMG7LOAm";

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
}
