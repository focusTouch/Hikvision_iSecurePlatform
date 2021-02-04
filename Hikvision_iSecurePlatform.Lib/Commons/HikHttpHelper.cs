using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace Hikvision_iSecurePlatform.Lib.Commons
{

    public class HikHttpHelper
    {

        public string HikiSecureAppKey { get; set; }
        public string HikiScureAppSecret { get; set; }
        public string HikiScureIp { get; set; }
        public int HikiScurePort { get; set; }
        public bool UseHttps { get; set; }
        public string HikiScureBaseUrl { get; set; }
        public int ReqtimeOut { get; set; }

        public HikHttpHelper(string HikiSecureAppKey, string HikiScureAppSecret, string HikiScureIp, int HikiScurePort = 443, bool UseHttps = true, int ReqtimeOut = 20000)
        {
            this.HikiSecureAppKey = HikiSecureAppKey;
            this.HikiScureAppSecret = HikiScureAppSecret;
            this.HikiScureIp = HikiScureIp;
            this.HikiScurePort = HikiScurePort;
            this.UseHttps = UseHttps;
            this.ReqtimeOut = ReqtimeOut;
            this.HikiScureBaseUrl = (UseHttps ? "https" : "http") + "://" + this.HikiScureIp + ((this.HikiScurePort == 80 || this.HikiScurePort == 443) ? "" : (":" + this.HikiScurePort));
        }

        public T HttpPostCast<T>(String reqUrl, Object reqBody = null, string contentType = "application/json")
        {
            T result = default(T);
            var buffer = HttpPost(reqUrl, reqBody, contentType);
            if (buffer == null)
            {

            }
            else if (typeof(T) == typeof(String))
            {
                var str = Encoding.UTF8.GetString(buffer);
                result = (T)(Object)str;
                Console.WriteLine("<<<<<<<======" + result);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();


            }
            else if (typeof(T) == typeof(byte[]))
            {
                result = (T)(Object)buffer;
            }
            else
            {
                var json = Encoding.UTF8.GetString(buffer);
                Console.WriteLine("<<<<<<<======" + json);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                result = JsonConvert.DeserializeObject<T>(json);
            }
            return result;
        }


        public byte[] HttpPost(String reqUrl, Object reqBody = null, string contentType = "application/json")
        {
            byte[] result = null;
            // this.HikiScureBaseUrl=this.HikiScureBaseUrl+"/artemis";
            if (!reqUrl.StartsWith("/artemis"))
            {
                reqUrl = "/artemis" + reqUrl;
            }


            // string text2 = "";

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Accept", "*/*");
            dictionary.Add("Content-Type", contentType);
            dictionary.Add("tagId", "1");
            // bool flag2 = ex_headers.Count > 0;
            // if (flag2)
            // {
            //     foreach (string key in ex_headers.Keys)
            //     {
            //         dictionary.Add(key, string.IsNullOrWhiteSpace(ex_headers[key]) ? "" : ex_headers[key]);
            //     }
            // }
            HikRequest request = new HikRequest(Method.POST_STRING, this.HikiScureBaseUrl, reqUrl, this.HikiSecureAppKey, this.HikiScureAppSecret, this.ReqtimeOut);
            request.Headers = dictionary;
            request.SignHeaderPrefixList = null;
            request.Querys = null;
            request.StringBody = JsonHelper.SerializeObjectIgnoreNull(reqBody == null ? new object() : reqBody);

            Console.WriteLine("==========================================");
            Console.WriteLine(request.Host);
            Console.WriteLine(request.Path);
            Console.WriteLine(request.Timeout);
            Console.WriteLine(JsonHelper.SerializeObject(request.Headers));
            Console.WriteLine(request.Querys == null ? "null" : JsonHelper.SerializeObject(request.Querys));
            Console.WriteLine(request.StringBody);
            Console.WriteLine(request.SignHeaderPrefixList);
            Console.WriteLine(request.AppKey);
            Console.WriteLine(request.AppSecret);
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("===>>>" + request.StringBody);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            return this.doPost(request.Host, request.Path, request.Timeout, request.Headers, request.Querys, request.StringBody, request.SignHeaderPrefixList, request.AppKey, request.AppSecret, true);


        }


        public string HttpPost(String reqUrl, string body, Dictionary<string, string> querys, string accept, string contentType, Dictionary<string, string> ex_headers, bool autoDown)
        {
            string result;
            if (!reqUrl.StartsWith("/artemis"))
            {
                reqUrl = "/artemis" + reqUrl;
            }


            string text2 = "";
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                string value = string.IsNullOrWhiteSpace(accept) ? "*/*" : accept;
                dictionary.Add("Accept", value);
                string value2 = string.IsNullOrWhiteSpace(contentType) ? "application/text;charset=UTF-8" : contentType;
                dictionary.Add("Content-Type", value2);
                bool flag2 = ex_headers.Count > 0;
                if (flag2)
                {
                    foreach (string key in ex_headers.Keys)
                    {
                        dictionary.Add(key, string.IsNullOrWhiteSpace(ex_headers[key]) ? "" : ex_headers[key]);
                    }
                }
                HikRequest request = new HikRequest(Method.POST_STRING, this.HikiScureBaseUrl, reqUrl, this.HikiSecureAppKey, this.HikiScureAppSecret, this.ReqtimeOut);
                request.Headers = dictionary;
                request.SignHeaderPrefixList = null;
                request.Querys = querys;
                request.StringBody = body;

                Console.WriteLine("==========================================");
                Console.WriteLine(request.Host);
                Console.WriteLine(request.Path);
                Console.WriteLine(request.Timeout);
                Console.WriteLine(JsonHelper.SerializeObject(request.Headers));
                Console.WriteLine(request.Querys == null ? "null" : JsonHelper.SerializeObject(request.Querys));
                Console.WriteLine(request.StringBody);
                Console.WriteLine(request.SignHeaderPrefixList);
                Console.WriteLine(request.AppKey);
                Console.WriteLine(request.AppSecret);
                Console.WriteLine("==========================================");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                return this.doPoststring(request.Host, request.Path, request.Timeout, request.Headers, request.Querys, request.StringBody, request.SignHeaderPrefixList, request.AppKey, request.AppSecret, autoDown);
            }
            catch (Exception ex)
            {
                // this.log.Info("接口请求报错:" + ex.Message);
            }
            result = text2;

            return result;
        }
        // Token: 0x04000001 RID: 1
        private string requestHeader;

        // Token: 0x04000002 RID: 2
        private static string ARTEMIS_PATH = "/artemis";
        public string doPoststring(string host, string path, int connectTimeout, Dictionary<string, string> headers, Dictionary<string, string> querys, string body, List<string> signHeaderPrefixList, string appKey, string appSecret, bool autoDown)
        {


            string result;
            try
            {
                headers = this.initialBasicHeader("POST", path, headers, querys, null, signHeaderPrefixList, appKey, appSecret);
                if (this.UseHttps)
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(RemoteCertificateValidate);
                    // ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
                    //  ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                }
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(this.initUrl(host, path, querys));
                httpWebRequest.KeepAlive = false;
                httpWebRequest.ProtocolVersion = HttpVersion.Version10;
                httpWebRequest.AllowAutoRedirect = false;
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = connectTimeout;
                string accept = headers["Accept"];
                httpWebRequest.Accept = accept;
                string contentType = headers["Content-Type"];
                httpWebRequest.ContentType = contentType;
                foreach (string text in headers.Keys)
                {
                    bool flag2 = text.Contains("x-ca-");
                    if (flag2)
                    {
                        httpWebRequest.Headers.Add(text + ":" + (string.IsNullOrWhiteSpace(headers[text]) ? "" : headers[text]));
                    }
                    bool flag3 = text.Equals("tagId");
                    if (flag3)
                    {
                        httpWebRequest.Headers.Add(text + ":" + (string.IsNullOrWhiteSpace(headers[text]) ? "" : headers[text]));
                    }
                }
                // this.log.Info("请求头信息: " + httpWebRequest.Headers.ToString());
                bool flag4 = !string.IsNullOrWhiteSpace(body);
                if (flag4)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(body);
                    httpWebRequest.ContentLength = (long)bytes.Length;
                    Stream requestStream = httpWebRequest.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }
                // this.log.Info("请求参数: " + body);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string text2 = "";
                bool flag5 = httpWebResponse.StatusCode == HttpStatusCode.OK;
                if (flag5)
                {
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        text2 = streamReader.ReadToEnd();
                    }
                }
                else
                {
                    bool flag6 = httpWebResponse.StatusCode == HttpStatusCode.Found;
                    if (flag6)
                    {
                        text2 = httpWebResponse.Headers["Location"].ToString();
                        httpWebResponse.Close();
                        if (autoDown)
                        {
                            this.HttpGetPicByUrl(text2);
                        }
                    }
                }
                result = text2;
            }
            catch (Exception ex)
            {
                result = "error:" + ex.Message;
            }
            return result;
        }

        public byte[] doPost(string host, string path, int connectTimeout, Dictionary<string, string> headers, Dictionary<string, string> querys, string body, List<string> signHeaderPrefixList, string appKey, string appSecret, bool autoDown)
        {


            byte[] result = null;
            headers = this.initialBasicHeader("POST", path, headers, querys, null, signHeaderPrefixList, appKey, appSecret);
            if (this.UseHttps)
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(RemoteCertificateValidate);
                // ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
                //  ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            }
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(this.initUrl(host, path, querys));
            httpWebRequest.KeepAlive = false;
            httpWebRequest.ProtocolVersion = HttpVersion.Version10;
            httpWebRequest.AllowAutoRedirect = false;
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = connectTimeout;
            string accept = headers["Accept"];
            httpWebRequest.Accept = accept;
            string contentType = headers["Content-Type"];
            httpWebRequest.ContentType = contentType;
            foreach (string text in headers.Keys)
            {
                bool flag2 = text.Contains("x-ca-");
                if (flag2)
                {
                    httpWebRequest.Headers.Add(text + ":" + (string.IsNullOrWhiteSpace(headers[text]) ? "" : headers[text]));
                }
                bool flag3 = text.Equals("tagId");
                if (flag3)
                {
                    httpWebRequest.Headers.Add(text + ":" + (string.IsNullOrWhiteSpace(headers[text]) ? "" : headers[text]));
                }
            }
            // this.log.Info("请求头信息: " + httpWebRequest.Headers.ToString());
            bool flag4 = !string.IsNullOrWhiteSpace(body);
            if (flag4)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(body);
                httpWebRequest.ContentLength = (long)bytes.Length;
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }
            // this.log.Info("请求参数: " + body);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            bool flag5 = httpWebResponse.StatusCode == HttpStatusCode.OK;
            if (flag5)
            {
                // Stream stream=httpWebResponse.GetResponseStream();
                Stream stream;
                stream = httpWebResponse.GetResponseStream();
                List<byte> bytes = new List<byte>();
                int temp = stream.ReadByte();
                while (temp != -1)
                {
                    bytes.Add((byte)temp);
                    temp = stream.ReadByte();
                }
                result = bytes.ToArray();



            }
            else
            {
                bool flag6 = httpWebResponse.StatusCode == HttpStatusCode.Found;
                if (flag6)
                {
                    var reqUrl = httpWebResponse.Headers["Location"].ToString();
                    httpWebResponse.Close();
                    if (autoDown)
                    {
                        result = this.HttpGetPicBufferByUrl(reqUrl);
                    }
                }
            }
            return result;
        }


        public byte[] HttpGetPicBufferByUrl(string picUrl)
        {
            WebClient webClient = new WebClient();
            return webClient.DownloadData(picUrl);
            // string text = Application.StartupPath + "\\downloadpics\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            // webClient.DownloadFile(picUrl, text);
            // this.log.Info("图片下载成功: " + text);

            return null;
        }

        public void HttpGetPicByUrl(string picUrl)
        {
            try
            {
                WebClient webClient = new WebClient();
                // string text = Application.StartupPath + "\\downloadpics\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                // webClient.DownloadFile(picUrl, text);
                // this.log.Info("图片下载成功: " + text);
            }
            catch (Exception ex)
            {
                // MessageBox.Show("图片下载失败:" + ex.Message + "图片可能已被覆盖，请前往平台查看相关图片是否正常！");
            }
        }


        public string initUrl(string host, string path, Dictionary<string, string> querys)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(host);
            bool flag = !string.IsNullOrWhiteSpace(path);
            if (flag)
            {
                stringBuilder.Append(path);
            }
            bool flag2 = querys != null;
            if (flag2)
            {
                StringBuilder stringBuilder2 = new StringBuilder();
                foreach (string text in querys.Keys)
                {
                    bool flag3 = 0 < stringBuilder2.Length;
                    if (flag3)
                    {
                        stringBuilder2.Append("&");
                    }
                    bool flag4 = string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(querys[text]);
                    if (flag4)
                    {
                        stringBuilder2.Append(querys[text]);
                    }
                    bool flag5 = !string.IsNullOrWhiteSpace(text);
                    if (flag5)
                    {
                        stringBuilder2.Append(text);
                        bool flag6 = !string.IsNullOrWhiteSpace(querys[text]);
                        if (flag6)
                        {
                            stringBuilder2.Append("=").Append(HttpUtility.UrlEncode(querys[text], Encoding.UTF8));
                        }
                    }
                }
                bool flag7 = 0 < stringBuilder2.Length;
                if (flag7)
                {
                    stringBuilder.Append("?").Append(stringBuilder2);
                }
            }
            return stringBuilder.ToString();
        }


        public Dictionary<string, string> initialBasicHeader(string method, string path, Dictionary<string, string> headers, Dictionary<string, string> querys, Dictionary<string, string> bodys, List<string> signHeaderPrefixList, string appKey, string appSecret)
        {
            bool flag = headers == null;
            if (flag)
            {
                headers = new Dictionary<string, string>();
            }
            headers["x-ca-timestamp"] = GetTimestamp(DateTime.Now).ToString();
            headers["x-ca-nonce"] = Guid.NewGuid().ToString();
            headers["x-ca-key"] = appKey;
            headers["x-ca-signature"] = this.sign(appSecret, method, path, headers, querys, bodys, signHeaderPrefixList);
            // this.log.Info("生成的签名: " + headers["x-ca-signature"]);
            return headers;
        }

        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }

        public static long GetTimestamp(DateTime time)
        {
            DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            return (time.Ticks - dateTime.Ticks) / 10000L;
        }

        public string sign(string secret, string method, string path, Dictionary<string, string> headers, Dictionary<string, string> querys, Dictionary<string, string> bodys, List<string> signHeaderPrefixList)
        {
            string result;
            try
            {
                string text = this.buildstringToSign(method, path, headers, querys, bodys, signHeaderPrefixList);
                // this.log.Info("生成签名的message: " + text);
                // this.log.Info("生成签名的secret: " + secret);
                result = this.HmacSHA256(text, secret);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        // Token: 0x06000015 RID: 21 RVA: 0x000034C0 File Offset: 0x000016C0
        public string buildstringToSign(string method, string path, Dictionary<string, string> headers, Dictionary<string, string> querys, Dictionary<string, string> bodys, List<string> signHeaderPrefixList)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(method.ToUpper()).Append("\n");
            bool flag = headers != null;
            if (flag)
            {
                bool flag2 = headers["Accept"] != null;
                if (flag2)
                {
                    stringBuilder.Append(headers["Accept"]);
                    stringBuilder.Append("\n");
                }
                bool flag3 = headers.Keys.Contains("Content-MD5") && headers["Content-MD5"] != null;
                if (flag3)
                {
                    stringBuilder.Append(headers["Content-MD5"]);
                    stringBuilder.Append("\n");
                }
                bool flag4 = headers["Content-Type"] != null;
                if (flag4)
                {
                    stringBuilder.Append(headers["Content-Type"]);
                    stringBuilder.Append("\n");
                }
                bool flag5 = headers.Keys.Contains("Date") && headers["Date"] != null;
                if (flag5)
                {
                    stringBuilder.Append(headers["Date"]);
                    stringBuilder.Append("\n");
                }
            }
            stringBuilder.Append(this.buildHeaders(headers, signHeaderPrefixList));
            stringBuilder.Append(this.buildResource(path, querys, bodys));
            return stringBuilder.ToString();
        }

        // Token: 0x06000016 RID: 22 RVA: 0x0000361C File Offset: 0x0000181C
        public string buildHeaders(Dictionary<string, string> headers, List<string> signHeaderPrefixList)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = signHeaderPrefixList != null;
            if (flag)
            {
                signHeaderPrefixList.Remove("x-ca-signature");
                signHeaderPrefixList.Remove("Accept");
                signHeaderPrefixList.Remove("Content-MD5");
                signHeaderPrefixList.Remove("Content-Type");
                signHeaderPrefixList.Remove("Date");
                signHeaderPrefixList.Sort();
            }
            bool flag2 = headers != null;
            if (flag2)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                IOrderedEnumerable<KeyValuePair<string, string>> orderedEnumerable = from objDic in headers
                                                                                     orderby objDic.Key
                                                                                     select objDic;
                StringBuilder stringBuilder2 = new StringBuilder();
                foreach (KeyValuePair<string, string> keyValuePair in orderedEnumerable)
                {
                    bool flag3 = keyValuePair.Key.Replace(" ", "").Contains("x-ca-");
                    if (flag3)
                    {
                        stringBuilder.Append(keyValuePair.Key + ":");
                        bool flag4 = !string.IsNullOrWhiteSpace(keyValuePair.Value);
                        if (flag4)
                        {
                            stringBuilder.Append(keyValuePair.Value);
                        }
                        stringBuilder.Append("\n");
                        bool flag5 = stringBuilder2.Length > 0;
                        if (flag5)
                        {
                            stringBuilder2.Append(",");
                        }
                        stringBuilder2.Append(keyValuePair.Key);
                    }
                }
                headers.Add("x-ca-signature-headers", stringBuilder2.ToString());
            }
            return stringBuilder.ToString();
        }

        // Token: 0x06000017 RID: 23 RVA: 0x000037C4 File Offset: 0x000019C4
        public string buildResource(string path, Dictionary<string, string> querys, Dictionary<string, string> bodys)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = !string.IsNullOrWhiteSpace(path);
            if (flag)
            {
                stringBuilder.Append(path);
            }
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            bool flag2 = querys != null;
            if (flag2)
            {
                IOrderedEnumerable<KeyValuePair<string, string>> orderedEnumerable = from objDic in querys
                                                                                     orderby objDic.Key
                                                                                     select objDic;
                foreach (KeyValuePair<string, string> keyValuePair in orderedEnumerable)
                {
                    bool flag3 = !string.IsNullOrWhiteSpace(keyValuePair.Key);
                    if (flag3)
                    {
                        dictionary[keyValuePair.Key] = keyValuePair.Value;
                    }
                }
            }
            bool flag4 = bodys != null;
            if (flag4)
            {
                IOrderedEnumerable<KeyValuePair<string, string>> orderedEnumerable2 = from objDic in bodys
                                                                                      orderby objDic.Key
                                                                                      select objDic;
                foreach (KeyValuePair<string, string> keyValuePair2 in orderedEnumerable2)
                {
                    bool flag5 = !string.IsNullOrWhiteSpace(keyValuePair2.Key);
                    if (flag5)
                    {
                        dictionary[keyValuePair2.Key] = keyValuePair2.Value;
                    }
                }
            }
            StringBuilder stringBuilder2 = new StringBuilder();
            IOrderedEnumerable<KeyValuePair<string, string>> orderedEnumerable3 = from objDic in dictionary
                                                                                  orderby objDic.Key
                                                                                  select objDic;
            foreach (KeyValuePair<string, string> keyValuePair3 in orderedEnumerable3)
            {
                bool flag6 = !string.IsNullOrWhiteSpace(keyValuePair3.Key);
                if (flag6)
                {
                    bool flag7 = stringBuilder2.Length > 0;
                    if (flag7)
                    {
                        stringBuilder2.Append("&");
                    }
                    stringBuilder2.Append(keyValuePair3.Key);
                    bool flag8 = !string.IsNullOrWhiteSpace(keyValuePair3.Value);
                    if (flag8)
                    {
                        stringBuilder2.Append("=").Append(keyValuePair3.Value);
                    }
                }
            }
            bool flag9 = 0 < stringBuilder2.Length;
            if (flag9)
            {
                stringBuilder.Append("?");
                stringBuilder.Append(stringBuilder2);
            }
            return stringBuilder.ToString();
        }

        // Token: 0x06000018 RID: 24 RVA: 0x00003A40 File Offset: 0x00001C40
        public string HmacSHA256(string message, string secret)
        {
            secret = (secret ?? "");
            UTF8Encoding utf8Encoding = new UTF8Encoding();
            byte[] bytes = utf8Encoding.GetBytes(secret);
            byte[] bytes2 = utf8Encoding.GetBytes(message);
            string result;
            using (HMACSHA256 hmacsha = new HMACSHA256(bytes))
            {
                byte[] inArray = hmacsha.ComputeHash(bytes2);
                result = Convert.ToBase64String(inArray);
            }
            return result;
        }

        // Token: 0x06000019 RID: 25 RVA: 0x00003AAC File Offset: 0x00001CAC
        public string ConvertJsonString(string str)
        {
            string result;
            try
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                TextReader reader = new StringReader(str);
                JsonTextReader reader2 = new JsonTextReader(reader);
                object obj = jsonSerializer.Deserialize(reader2);
                bool flag = obj != null;
                if (flag)
                {
                    StringWriter stringWriter = new StringWriter();
                    JsonTextWriter jsonWriter = new JsonTextWriter(stringWriter)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4,
                        IndentChar = ' '
                    };
                    jsonSerializer.Serialize(jsonWriter, obj);
                    result = stringWriter.ToString();
                }
                else
                {
                    result = str;
                }
            }
            catch (Exception ex)
            {
                result = str;
            }
            return result;
        }

    }


}
