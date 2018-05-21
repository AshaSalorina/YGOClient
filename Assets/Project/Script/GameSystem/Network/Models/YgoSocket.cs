using Egan.Exceptions;
using Egan.Tools;
using System;
using System.Net.Sockets;
using System.Threading;

namespace Egan.Models
{
    public class YgoSocket : Socket
    {

        private YGOPDecoder decoder;

        public YgoSocket() : 
            base(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp){}


        /// <summary>
        /// 开始连接远程主机并接收消息
        /// </summary>
        /// <param name="host">远程主机地址</param>
        /// <param name="port">远程主机端口</param>
        public void Start(string host, int port)
        {
            try
            {
                Console.WriteLine("正在连接服务器...");
                Connect(host, port);
                Console.WriteLine("连接服务器成功");

                //创建编码器
                decoder = new YGOPDecoder(this);

                //创建后台线程接收服务器消息
                Thread threadReceive = new Thread(ReceiveMsg);
                threadReceive.IsBackground = true;
                threadReceive.Start();
            }
            catch
            {
                throw new RException("网络连接失败");
            }
        }

        /// <summary>
        /// 接收来自远程主机的消息
        /// </summary>
        private void ReceiveMsg()
        {
            byte[] buffer = new byte[1024];
            //分段接收服务器信息
            while (true)
            {
                if (decoder.ReceivePacket())
                {
                    DataPacket packet = decoder.ParsePacket();
                    Console.WriteLine(
                        $"+——--------——+——-----------——+——------------——+——-------——+\n" +
                        $"|  {packet.Version}  | {packet.Type.ToString()}  |  {packet.Magic}  |  {packet.Len}  |  {packet.Body}  |\n" +
                        $"+——--------——+——-----------——+——------------——+——-------——+\n"
                        );
                }
            }
        }
    }
}
