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
        /// <summary>
        /// 是否终止线程receiver的flag
        /// </summary>
        private Boolean stopFlag;

        public YgoSocket() : 
            base(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp){}

        /// <summary>
        /// 开始连接
        /// </summary>
        /// <param name="host">远程主机地址</param>
        /// <param name="port">远程主机端口</param>
        /// <param name="start">消息处理方法</param>
        /// <param name="flag">消息处理方法的终止变量</param>
        public void Start(string host, int port, ThreadStart start = null, Boolean flag = false)
        {
            try
            {
                Console.WriteLine("正在连接服务器...");
                Connect(host, port);
                Console.WriteLine("连接服务器成功");

                //创建编码器
                decoder = new YGOPDecoder(this);

                //如果需要，创建一个线程持续接收服务器的消息
                if(start != null)
                {
                    receiver = new Thread(start);
                    receiver.IsBackground = true;
                    receiver.Start();
                }
            }
            catch
            {
                throw new RException("网络连接失败");
            }
        }


        public void ShutdownGracefully()
        {
            try
            {
                if (Connected)
                {
                    Shutdown(SocketShutdown.Both);
                    Close();
                    stopFlag = true;
                }
            }catch(Exception e)
            {
                throw RExceptionFactory.Generate(e);
            }
         
        }

        /// <summary>
        /// 接收并返回一个完整的数据包
        /// 超时时抛出RException异常
        /// </summary>
        public DataPacket ReceivePacket()
        {
            Stopwatch wacth = new Stopwatch();
            wacth.Start();
            while (true)
            {
                if (wacth.ElapsedMilliseconds > ProtocolConstant.TIME_OUT)
                    throw RExceptionFactory.Generate(wacth.ElapsedMilliseconds);
                if (decoder.ReceivePacket())
                {
                    DataPacket packet = decoder.ParsePacket();
                    PrintPacket(packet);
                    return packet;
                }
            }
        }

        public static void PrintPacket(DataPacket packet)
        {
            Console.WriteLine(
                        $"+——--------——+——-----------——+——------------——+——-------——+\n" +
                        $"|  {packet.Version}  | {packet.Type.ToString()}  |  {packet.Magic}  |  {packet.Len}  |  {packet.Body}  |\n" +
                        $"+——--------——+——-----------——+——------------——+——-------——+\n"
                        );
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
