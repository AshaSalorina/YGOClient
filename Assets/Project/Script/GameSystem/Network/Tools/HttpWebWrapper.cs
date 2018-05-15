﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Tools
{
    public class HttpWebWrapper
    {
        /// <summary>
        /// 模拟HTTP的get方法
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/plain;charset=utf-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream respStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(respStream,
                Encoding.GetEncoding("utf-8"));
            string result = reader.ReadToEnd();
            reader.Close();
            respStream.Close();

            return result;

        }

        /// <summary>
        /// 模拟HTTP的Post方法
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="data">向服务器POST的数据</param>
        /// <returns></returns>
        public static String Post(string url, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(data);

            Stream reqStream = request.GetRequestStream();
            StreamWriter writer = new StreamWriter(reqStream, Encoding.UTF8);
            writer.Write(data);
            writer.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream respStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(respStream, Encoding.UTF8);

            string result = reader.ReadToEnd();

            reader.Close();
            respStream.Close();

            return result;
        }
    }
}