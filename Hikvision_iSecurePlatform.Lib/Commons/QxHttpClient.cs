// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Net;
// using System.Net.Http;
// using System.Runtime.InteropServices;
// using System.Security.Cryptography;
// using System.Text;
// using System.Threading;
// using System.Threading.Tasks;

// namespace Hikvision_iSecurePlatform.Lib.Commons
// {
//     public class QxHttpClient
//     {
//         public static long RequestCount;
//         public HttpClient _httpClient = null;
//         HttpClientHandler handler = null;

//         public string _appkey = null;
//         public string _secret = null;
//         public string _baseUrl = null;

//         /// <summary>
//         /// 默认语言
//         /// </summary>
//         public Encoding DefaultEncoding = Encoding.UTF8;

//         public delegate void HttpProgress(int progress);
//         //public event HttpProgress HttpDownloadProgressEvent;

//         public QxHttpClient()
//         {

//             cookieContainer = new CookieContainer();
            
//              handler = new HttpClientHandler();
//             handler.ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true;
//             handler.CookieContainer=cookieContainer;
//             handler.AllowAutoRedirect=true;
//             handler.UseCookies=true;
//             handler.UseProxy=true;
//             _httpClient = new HttpClient(handler);
//         }
//         public QxHttpClient(string proxyIp, int proxyPort, string proxyAccount, string proxyPassword)
//         {
//             cookieContainer = new CookieContainer();

//             WebProxy wp = new WebProxy(proxyIp, proxyPort);
//             //代理地址
//             //设置身份验证凭据 账号 密码
//             wp.Credentials = new NetworkCredential(proxyAccount, proxyPassword);

//             handler = new HttpClientHandler() { CookieContainer = cookieContainer, AllowAutoRedirect = true, UseCookies = true, Proxy = wp };
//             _httpClient = new HttpClient();

//         }

//         #region Head相关

//         public void AddHeader(string key, String value)
//         {

//             RemoveHeader(key);
//             _httpClient.DefaultRequestHeaders.Add(key, value);
//         }

//         public Dictionary<String, String> Heads
//         {
//             get
//             {
//                 Dictionary<String, String> head = new Dictionary<string, string>();
//                 foreach (var item in _httpClient.DefaultRequestHeaders)
//                 {
//                     head.Add(item.Key, String.Join(";", item.Value));
//                 }
//                 return head;
//             }
//         }

//         public void RemoveHeader(string key)
//         {
//             if (_httpClient.DefaultRequestHeaders.Contains(key))
//                 _httpClient.DefaultRequestHeaders.Remove(key);
//         }

//         #endregion
//         #region Cookie相关

//         public CookieContainer cookieContainer = null;
//         public Dictionary<String, String> Cookies
//         {
//             get
//             {
//                 Dictionary<String, String> cookies = new Dictionary<string, string>();
//                 if (cookieContainer != null)
//                 {

//                     Hashtable table = (Hashtable)cookieContainer.GetType().InvokeMember("m_domainTable",
//                         System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
//                         System.Reflection.BindingFlags.Instance, null, cookieContainer, new object[] { });
//                     foreach (object pathList in table.Values)
//                     {
//                         SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
//                             System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
//                             System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
//                         foreach (CookieCollection colCookies in lstCookieCol.Values)
//                             foreach (Cookie c in colCookies)
//                             {

//                                 if (cookies.ContainsKey(c.Name))
//                                     cookies[c.Name] = c.Value;
//                                 else
//                                     cookies.Add(c.Name, c.Value);
//                             }
//                     }
//                 }
//                 return cookies;
//             }
//         }

//         #endregion
//         public T Get<T>(string url, bool ignoreHttpErrorrCode = false)
//         {
//             Interlocked.Increment(ref RequestCount);
//             Object result = null;
//             string accept = "*/*";// "*/*";
//             this._httpClient.DefaultRequestHeaders.Add("Accept", accept);
//             // this._httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
//             string timestamp = ((DateTime.Now.Ticks - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).Ticks) / 1000).ToString();
//             this._httpClient.DefaultRequestHeaders.Add("x-ca-timestamp", timestamp);
//             // x-ca-nonce
//             string nonce = System.Guid.NewGuid().ToString();
//             this._httpClient.DefaultRequestHeaders.Add("x-ca-nonce", nonce);
//             // x-ca-key
//             this._httpClient.DefaultRequestHeaders.Add("x-ca-key", _appkey);
//             // build string to sign
//             string strToSign = buildSignString("GET", url);
//             string signedStr = computeForHMACSHA256(strToSign, _secret);
//             // x-ca-signature
//             this._httpClient.DefaultRequestHeaders.Add("x-ca-signature", signedStr);
//             var httpResult = _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url)).Result;
//             if (ignoreHttpErrorrCode || httpResult.StatusCode == HttpStatusCode.OK)
//             {
//                 var buffer = httpResult.Content.ReadAsByteArrayAsync().Result;
//                 result = CastObj<T>(buffer);

//             }
//             else
//             {
//                 // return default(T);
//             }
//             return (T)result;
//         }

//         public T Post<T>(string url, string data, string contentType = "application/json", bool ignoreHttpErrorrCode = true)
//         {
//             Interlocked.Increment(ref RequestCount);
//             Object result = null;
//             StringContent content = new StringContent(data, DefaultEncoding, contentType);

//             string accept = "*/*";// "*/*";
//             this._httpClient.DefaultRequestHeaders.Clear();
//             this._httpClient.DefaultRequestHeaders.Add("Accept", accept);
//             //  this._httpClient.DefaultRequestHeaders.Add("Content-Type", contentType);
//             string contentMd5 = computeContentMd5(data);

//             content.Headers.Add("content-md5", contentMd5);
//             string timestamp = ((DateTime.Now.Ticks - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).Ticks) / 1000).ToString();
//             content.Headers.Add("x-ca-timestamp", timestamp);
//             // x-ca-nonce
//             string nonce = System.Guid.NewGuid().ToString();
//             content.Headers.Add("x-ca-nonce", nonce);
//             // x-ca-key
//             content.Headers.Add("x-ca-key", _appkey);
//             // build string to sign
//             string strToSign = buildSignString("POST", url, content);
//             string signedStr = computeForHMACSHA256(strToSign, _secret);
//             // x-ca-signature
//             content.Headers.Add("x-ca-signature", signedStr);
            

//             HttpResponseMessage httpResult = _httpClient.PostAsync(new Uri(_baseUrl + url), content).Result;
//             if (ignoreHttpErrorrCode || httpResult.StatusCode == HttpStatusCode.OK)
//             {
//                 var buffer = httpResult.Content.ReadAsByteArrayAsync().Result;
//                 result = CastObj<T>(buffer);
//             }
//             else
//             {
//                 //return default(T);
//             }
//             return (T)result;
//         }

//         public T Post<T>(string url, QxHttpPara data, string contentType, bool ignoreHttpErrorrCode = false)
//         {
//             return Post<T>(url, data.ParaStr, contentType, ignoreHttpErrorrCode);
//         }
//         public T PostJson<T>(string url, QxHttpPara data, bool ignoreHttpErrorrCode = false)
//         {
//             return Post<T>(url, data.ToString(), "application/json", ignoreHttpErrorrCode);
//         }



//         private T CastObj<T>(byte[] buffer)
//         {
//             if (buffer == null)
//                 return default(T);
//             Object result = null;
//             if (typeof(T) == typeof(String))
//             {
//                 result = DefaultEncoding.GetString((byte[])buffer);
//             }
//             else if (typeof(T) == typeof(byte[]))
//             {
//                 result = buffer;
//             }
//             else //不是String 不是byte[] ,那肯定是对象,直接转为对象
//             {
//                 var json = DefaultEncoding.GetString((byte[])buffer);
//                 // Console.WriteLine (json);
//                 // System.Text.Json.JsonSerializerOptions options = new System.Text.Json.JsonSerializerOptions();
//                 //options.Converters.Add(new BoolJsonConverter());
//                 result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
//             }
//             return (T)result;
//         }


//         /// <summary>
//         /// 计算签名字符串
//         /// </summary>
//         /// <param name="method">HTTP请求方法，如“POST”</param>
//         /// <param name="url">接口Url，如/artemis/api/resource/v1/org/advance/orgList</param>
//         /// <param name="header">请求头</param>
//         /// <returns>签名字符串</returns>
//         private string buildSignString(string method, string url, StringContent stringContent = null)
//         {
//             StringBuilder sb = new StringBuilder();
//             sb.Append(method.ToUpper()).Append("\n");

//             if (null != this.Heads)
//             {

//                 if (null != this.Heads["Accept"])
//                 {
//                     sb.Append((string)this.Heads["Accept"]);
//                     sb.Append("\n");
//                 }
//             if (stringContent.Headers.Where(p => p.Key == "Content-Type").Any())
//                 {
//                     sb.Append(stringContent.Headers.Where(p => p.Key == "Content-Type").FirstOrDefault().Value.FirstOrDefault());
//                     sb.Append("\n");
//                 }
//                 if (stringContent.Headers.Where(p => p.Key == "Content-MD5").Any())
//                 {
//                     sb.Append(stringContent.Headers.Where(p => p.Key == "Content-MD5").FirstOrDefault().Value.FirstOrDefault());
//                     sb.Append("\n");
//                 }

               

//                 if (stringContent.Headers.Where(p => p.Key == "x-ca-timestamp").Any() && null != stringContent.Headers.Where(p => p.Key == "x-ca-timestamp").FirstOrDefault().Value)
//                 {
//                     sb.Append(stringContent.Headers.Where(p => p.Key == "x-ca-timestamp").FirstOrDefault().Value.FirstOrDefault());
//                     sb.Append("\n");
//                 }
//             }

//             // build and add header to sign
//             string signHeader = buildSignHeader(stringContent);
//             sb.Append(signHeader);
//             sb.Append("/artemis"+url);
//             var x=sb.ToString();
//             Console.WriteLine(x);
//             return sb.ToString();
//         }

//         /// <summary>
//         /// 计算签名头
//         /// </summary>
//         /// <param name="header">请求头</param>
//         /// <returns>签名头</returns>
//         private string buildSignHeader(StringContent stringContent)
//         {
//             Dictionary<string, string> sortedDicHeader = new Dictionary<string, string>();
          
//             StringBuilder sbSignHeader = new StringBuilder();
//             StringBuilder sb = new StringBuilder();
//             foreach (var kvp in stringContent.Headers)
//             {
//                 if (kvp.Key.Replace(" ", "").Contains("x-ca-"))
//                 {
//                     sb.Append(kvp.Key + ":");
//                     if (!string.IsNullOrWhiteSpace(kvp.Value.FirstOrDefault()))
//                     {
//                         sb.Append(kvp.Value);
//                     }
//                     sb.Append("\n");
//                     if (sbSignHeader.Length > 0)
//                     {
//                         sbSignHeader.Append(",");
//                     }
//                     sbSignHeader.Append(kvp.Key);
//                 }
//             }
//             _httpClient.DefaultRequestHeaders.Add("x-ca-signature-headers", sbSignHeader.ToString());
//             return sb.ToString();
//         }

//         /// <summary>
//         /// 计算content-md5
//         /// </summary>
//         /// <param name="body"></param>
//         /// <returns>base64后的content-md5</returns>
//         private static string computeContentMd5(string body)
//         {
//             MD5 md5 = new MD5CryptoServiceProvider();
//             byte[] result = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(body));
//             return Convert.ToBase64String(result);
//         }



//         /// <summary>
//         /// 计算HMACSHA265
//         /// </summary>
//         /// <param name="str">待计算字符串</param>
//         /// <param name="secret">平台APPSecet</param>
//         /// <returns>HMAXH265计算结果字符串</returns>
//         private static string computeForHMACSHA256(string str, string secret)
//         {
//             var encoder = new System.Text.UTF8Encoding();
//             byte[] secretBytes = encoder.GetBytes(secret);
//             byte[] strBytes = encoder.GetBytes(str);
//             var opertor = new HMACSHA256(secretBytes);
//             byte[] hashbytes = opertor.ComputeHash(strBytes);
//             return Convert.ToBase64String(hashbytes);
//         }
//     }

//     public class QxHttpPara
//     {
//         private Dictionary<String, String> _data = null;
//         public QxHttpPara()
//         {
//             _data = new Dictionary<string, string>();
//         }
//         public QxHttpPara(string key, string value) : this()
//         {
//             _data.Add(key, value);
//         }
//         public QxHttpPara AddPara(string key, string value)
//         {
//             if (_data.ContainsKey(key))
//                 _data[key] = value;
//             else
//                 _data.Add(key, value);
//             return this;
//         }
//         public QxHttpPara AddUrlEncodePara(string key, string value)
//         {
//             if (_data.ContainsKey(key))
//                 _data[key] = Tools.URLEncode(value);
//             else
//                 _data.Add(key, Tools.URLEncode(value));
//             return this;
//         }
//         public override String ToString()
//         {
//             return Newtonsoft.Json.JsonConvert.SerializeObject(this._data);
//         }
//         public String ParaStr
//         {
//             get
//             {
//                 StringBuilder result = new StringBuilder();
//                 if (_data.Count != 0)
//                 {
//                     int index = 0;
//                     foreach (var item in _data.Keys)
//                     {
//                         if (index != 0)
//                             result.Append("&");
//                         result.Append(item);
//                         result.Append("=");
//                         result.Append(_data[item]);
//                         index++;
//                     }
//                 }
//                 return result.ToString();
//             }
//         }
//     }
// }