using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace Egan
{
    /// <summary>
    /// 与决斗服务器交互的socket客户端类
    /// </summary>
    public class DuelClient
    {
        private const string IP = "";
        private const int PORT = 2333;

        private Socket client;

        /// <summary>
        /// 开始连接
        /// </summary>
        public void Start()
        {
            try
            {
                
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Console.WriteLine("正在连接服务器...");
                client.Connect(IP, PORT);
                Console.WriteLine("连接服务器成功");

                //创建后台线程接收服务器消息
                Thread threadReceive = new Thread(ReceiveMsg);
                threadReceive.IsBackground = true;
                threadReceive.Start();
            }
            catch
            {
                Console.WriteLine("连接服务器失败");
            }
        }


        private void ReceiveMsg()
        {
            byte[] buffer = new byte[1024];
            int len = 0;
            //分段接收服务器信息?
            while (true)
            {
                len = client.Receive(buffer);
                if(len > 0)
                    Console.WriteLine($"服务器：{Encoding.UTF8.GetString(buffer, 0, len - 1)}");
            }
        }

        /// <summary>
        /// 发送游戏操作消息
        /// </summary>
        /// <param name="msg"></param>
        public void SendOPMsg(String msg)
        {
            client.Send(Encoding.UTF8.GetBytes("o" + msg));
        }

        /// <summary>
        /// 发送聊天消息
        /// </summary>
        /// <param name="msg"></param>
        public void SendChatMsg(String msg)
        {
            client.Send(Encoding.UTF8.GetBytes("c" + msg));
        }


        public void Close()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
