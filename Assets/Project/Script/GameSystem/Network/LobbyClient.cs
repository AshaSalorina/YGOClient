using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Egan
{
    /// <summary>
    /// 游戏大厅客户端类
    /// </summary>
    class LobbyClient
    {

        private const string URL = "";

        /// <summary>
        /// 获取房间列表信息
        /// </summary>
        public void GetRoomList()
        {

        }

        /// <summary>
        /// 模拟Http的Get方法
        /// </summary>
        /// <returns></returns>
        private string HttpGet()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
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
        /// 模拟Http的post方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string HttpPost(string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
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
