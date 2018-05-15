using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tool.Egan
{
    /// <summary>
    /// Http封装类
    /// </summary>
    public class HttpWebWrapper
    {
        /// <summary>
        /// 模拟HTTP的GET方法
        /// </summary>
        /// <param name="url"></param>
        /// <returns>服务器的响应结果</returns>
        public static string HttpGet(String url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader steamReader = new StreamReader(stream, Encoding.UTF8);
            string result = steamReader.ReadToEnd();
            steamReader.Close();
            stream.Close();

            return result;
        }

        /// <summary>
        /// 模拟Http的POST方法
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="data">需要post的数据</param>
        /// <returns>服务器的响应结果</returns>
        public static string HttpPost(string url, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(data);

            Stream requestStream = request.GetRequestStream();
            StreamWriter writer = new StreamWriter(requestStream, Encoding.UTF8);
            writer.Write(data);
            writer.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            string result = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();

            return result;

        }
    }
}
