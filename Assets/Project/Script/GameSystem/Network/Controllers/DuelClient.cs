using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using Egan.Tools;
using Egan.Models;

namespace Egan.Cotrollers
{
    /// <summary>
    /// 与决斗服务器交互的socket客户端类
    /// </summary>
    public class DuelClient
    {
        private string IP = "";
        private int PORT = 2333;

        private Socket client;

        private YGOPDecoder decoder;

        public DuelClient(string IP, int PORT)
        {
            this.IP = IP;
            this.PORT = PORT;
        }

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

                //创建编码器
                decoder = new YGOPDecoder(client);

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
            //分段接收服务器信息
            while (true)
            {
                if (decoder.ReceivePacket())
                {
                    YGOPDataPacket packet = decoder.ParsePacket();
                    Console.WriteLine(
                        $"+——--------——+——-----------——+——------------——+——-------——+\n" +
                        $"|  {packet.Version}  | ${packet.Type.ToString()}  |  ${packet.Magic}  |  ${packet.Len}  |  ${packet.Body}  |\n" +
                        $"+——--------——+——-----------——+——------------——+——-------——+\n"
                        );
                }
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
