using Asha;
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
        /// 解码器
        /// </summary>
        private YGOPDecoder decoder;
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
        public void Start(string host, int port)
        {
            try
            {
                Connect(host, port);

                //创建编码器
                Decoder = new YGOPDecoder(this);
                
            }
            catch(WebException wex)
            {
                throw new RException("网络连接失败");
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
                    Close();
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
            try
            {
                while (true)
                {
                    if (wacth.ElapsedMilliseconds > YGOP.TIME_OUT)
                        throw RExceptionFactory.Generate(wacth.ElapsedMilliseconds);
                    if (Decoder.ReceivePacket())
                    {
                        DataPacket packet = Decoder.ParsePacket();
                        PrintPacket(packet);

                        if (packet.Type == MessageType.WARRING)
                        {
                            R r = JsonConvert.DeserializeObject<R>(packet.Body);
                            throw RExceptionFactory.Generate(r);
                        }

                        return packet;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public static void PrintPacket(DataPacket packet)
        {
            //WarningBox.Show($"+——--------——+——-----------——+——------------——+——-------——+\n" +
            //            $"|  {packet.Version}  | {packet.Type.ToString()}  |  {packet.Magic}  |  {packet.Len}  |  {packet.Body}  |\n" +
            //            $"+——--------——+——-----------——+——------------——+——-------——+\n");
            Console.WriteLine(
                        $"+——--------——+——-----------——+——------------——+——-------——+\n" +
                        $"|  {packet.Version}  | {packet.Type.ToString()}  |  {packet.Magic}  |  {packet.Len}  |  {packet.Body}  |\n" +
                        $"+——--------——+——-----------——+——------------——+——-------——+\n"
                        );
        }

        public YGOPDecoder Decoder
        {
            get
            {
                return decoder;
            }

            set
            {
                decoder = value;
            }
        }

    }
}
