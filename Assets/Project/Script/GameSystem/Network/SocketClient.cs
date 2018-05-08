using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace Egan
{
    public class SocketClient
    {
        private const string IP = "";
        private const int PORT = 2333;

        private Socket client;

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

        public void Send(String msg)
        {
            client.Send(Encoding.UTF8.GetBytes(msg));
        }

        public void CreateRoom(String id, String name, String password)
        {
        }


        public void Close()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
