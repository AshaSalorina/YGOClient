using Egan.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            request.Timeout = 10000;

            string result = "";

            Stream stream = null;
            StreamReader reader = null;

            Stopwatch watch = new Stopwatch();
            watch.Start();
            try
            {
                
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();
                reader = new StreamReader(stream,
                    Encoding.GetEncoding("utf-8"));
                result = reader.ReadToEnd();
            }catch(WebException)
            {
                throw RExceptionHandler.Handle(request.Timeout, watch.Elapsed.TotalMilliseconds);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (stream != null)
                    stream.Close();
                watch.Stop();
            }

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

            byte[] bytes = Encoding.UTF8.GetBytes(data);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            request.Timeout = 10000;

            string result = "";

            Stream writer = null, stream = null;
            StreamReader reader = null;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            try
            {
                writer = request.GetRequestStream();
                writer.Write(bytes, 0, bytes.Length);

                watch.Restart();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();
                reader = new StreamReader(stream, Encoding.UTF8);

                result = reader.ReadToEnd();
                
            }catch(WebException)
            {
                throw RExceptionHandler.Handle(request.Timeout, watch.Elapsed.TotalMilliseconds);
            }
            finally
            {
                watch.Stop();
                if(writer != null)
                    writer.Close();
                if (reader != null)
                    reader.Close();
                if(stream != null)
                    stream.Close();
            }

            return result;

        }
    }
}
