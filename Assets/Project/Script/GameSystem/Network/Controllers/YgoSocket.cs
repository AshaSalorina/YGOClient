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
                if (isConnected())
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

        public bool isConnected()
        {
                bool blockingState = Blocking;
                try
                {
                    Blocking = false;
                    DataPacket packet = new DataPacket("", MessageType.TEST);
                    base.Send(YGOPEncoder.Encoder(packet));
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
                finally
                {
                    try {
                    // 恢复状态
                    Blocking = blockingState;
                    } catch { };

                }
        }
    }
}
