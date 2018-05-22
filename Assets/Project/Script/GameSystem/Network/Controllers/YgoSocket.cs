using Egan.Constants;
using Egan.Exceptions;
using Egan.Models;
using Egan.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Egan.Controllers
{
    class YgoSocket : Socket
    {
        /// <summary>
        /// 数据包队列
        /// </summary>
        public static List<DataPacket> packetQueue = new List<DataPacket>();

        /// <summary>
        /// 解码器
        /// </summary>
        private YGOPDecoder decoder;
        /// <summary>
        /// 处理服务器消息的控制器
        /// </summary>
        private ReceiveController controller;
        /// <summary>
        /// 接收服务器消息的线程
        /// </summary>
        private Thread receiver;

        public YgoSocket() : 
            base(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp){}

        /// <summary>
        /// 开始连接
        /// </summary>
        /// <param name="host">远程主机地址</param>
        /// <param name="port">远程主机端口</param>
        /// <param name="start">消息处理方法</param>
        public void Start(string host, int port, ReceiveController controller = null)
        {
            try
            {
                //Console.WriteLine("正在连接服务器...");
                Connect(host, port);
                //Console.WriteLine("连接服务器成功");

                //创建编码器
                decoder = new YGOPDecoder(this);

                //如果需要，创建一个线程持续接收服务器的消息
                if(receiver != null)
                {
                    receiver = new Thread(controller.ReceiveMessage);
                    receiver.IsBackground = true;
                    receiver.Start();
                }
            }
            catch(WebException wex)
            {
                Console.WriteLine(wex.ToString());
                //throw new RException("网络连接失败");
            }
        }

        /// <summary>
        /// 优雅地关闭Socket
        /// </summary>
        public void ShutdownGracefully()
        {
            try
            {
                if (Connected)
                {
                    Shutdown(SocketShutdown.Both);
                    //Close();
                    if(controller != null)
                        controller.Stop = true;
                }
            }catch(Exception e)
            {
                throw RExceptionFactory.Generate(e);
            }
         
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="body">消息体</param>
        /// <param name="type">消息类型</param>
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

        /// <summary>
        /// 接收并返回一个完整的数据包
        /// 超时或消息类型为警告时抛出RException异常
        /// </summary>
        public DataPacket ReceivePacket()
        {
            Stopwatch wacth = new Stopwatch();
            wacth.Start();
            while (true)
            {
                if (wacth.ElapsedMilliseconds > YGOP.TIME_OUT)
                    throw RExceptionFactory.Generate(wacth.ElapsedMilliseconds);
                if (decoder.ReceivePacket())
                {
                    DataPacket packet = decoder.ParsePacket();
                    PrintPacket(packet);

                    if(packet.Type == MessageType.WARRING)
                    {
                        R r = JsonConvert.DeserializeObject<R>(packet.Body);
                        throw RExceptionFactory.Generate(r);
                    }
                        

                    return packet;
                }
            }
        }

        public static void PrintPacket(DataPacket packet)
        {
            //Console.WriteLine(
            //            $"+——--------——+——-----------——+——------------——+——-------——+\n" +
            //            $"|  {packet.Version}  | {packet.Type.ToString()}  |  {packet.Magic}  |  {packet.Len}  |  {packet.Body}  |\n" +
            //            $"+——--------——+——-----------——+——------------——+——-------——+\n"
            //            );
        }
    }
}
