﻿using System;
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
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="downloadUrl"></param>
        /// <param name="filename"></param>
        /// <param name="filepath"></param>
        public static void downfile(string downloadUrl, string filename)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(downloadUrl);
            request.Headers.Add("Authorization", "Bearer " + Common.user.Token);
            request.Timeout = 15000;
            HttpWebResponse hwp = (HttpWebResponse)request.GetResponse();
            Stream ss = hwp.GetResponseStream();
            byte[] buffer = new byte[10240];
            //if (!Directory.Exists(filepath))
            //{
            //    Directory.CreateDirectory(filepath);
            //}
            //if (!File.Exists(filename))
            //{
            //    File.Create(filename);
               
            //}
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            try
            {
                int i;
                while ((i = ss.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, i);
                }
                fs.Close();
                ss.Close();
            }
            catch (Exception)
            {
                fs.Close();
                ss.Close();
                throw;
            }


        }

    }
}
