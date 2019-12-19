using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MdTools.Result;
using Newtonsoft.Json;

namespace MdTools
{
    class Http
    {


        private static readonly Lazy<Http> _instance = new Lazy<Http>(() => new Http());

        public static Http Instance => _instance.Value;
        /// <summary>
        /// 发送请求的方法
        /// </summary>
        /// <param name="Url">地址</param>
        /// <param name="postDataStr">数据</param>
        /// <returns></returns>
        public dynamic HttpPost<T>(string Url, string postDataStr, bool needAuthorize=false)
        {
            try
            {
                //转换输入参数的编码类型，获取bytep[]数组 
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "application/json";
               // request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
                if (needAuthorize && Common.user != null)
                {
                    request.Headers.Add("Authorization", "Bearer " + Common.user.Token);
                }
                Stream myRequestStream = request.GetRequestStream();
                StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("utf-8"));
                myStreamWriter.Write(postDataStr);
                myStreamWriter.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return JsonConvert.DeserializeObject<T>(retString);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public dynamic HttpGet<T>(string Url, string postDataStr, bool needAuthorize = false)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                if (needAuthorize && Common.user != null)
                {
                    request.Headers.Add("Authorization", "Bearer " + Common.user.Token);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return JsonConvert.DeserializeObject<T>(retString);
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

    }
}
