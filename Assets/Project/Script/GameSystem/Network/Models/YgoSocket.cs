using Egan.Constants;
using Egan.Exceptions;
using Egan.Tools;
using System;
using System.Diagnostics;
using System.Net;
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
        /// 开始连接
        /// </summary>
        /// <param name="host">远程主机地址</param>
        /// <param name="port">远程主机端口</param>
        /// <param name="start">远程消息处理方法</param>
        public void Start(string host, int port, ThreadStart start = null)
        {
            try
            {
                Console.WriteLine("正在连接服务器...");
                Connect(host, port);
                Console.WriteLine("连接服务器成功");

                //创建编码器
                decoder = new YGOPDecoder(this);

                //创建后台线程接收服务器消息
                Thread threadReceive = new Thread(start == null ? ReceiveMsg : start);
                threadReceive.IsBackground = true;
                threadReceive.Start();
            }
            catch
            {
                throw new RException("网络连接失败");
            }
        }

        /// <summary>
        /// 默认的对远程主机的消息的处理方法
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

        public void Send(String body, MessageType type)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            try
            {
                DataPacket packet = new DataPacket(body, type);

                base.Send(YGOPEncoder.Encoder(packet));
            }
            catch (WebException)
            {
                throw RExceptionFactory.Generate(watch.ElapsedMilliseconds);
            }
        }
    }
}
