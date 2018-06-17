using System;
using System.Collections.Generic;
using Asha;
using Egan.Constants;
using Egan.Exceptions;
using Egan.Models;
using Egan.Tools;
using Network.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Egan.Controllers
{
    /// <summary>
    /// 大厅接收器
    /// 处理来自游戏大厅的消息
    /// </summary>
    class LobbyReceiver : AbstractReceiver
    {
 
        public LobbyReceiver(YGOPDecoder decoder)
        {
            this.decoder = decoder;
        }

        public override void ReceiveMessage()
        {

            try
            {
                while (!stop)
                {
                    if (decoder.ReceivePacket())
                    {
                        DataPacket packet = decoder.ParsePacket();
                        //YgoSocket.PrintPacket(packet);
                        Options.YGOWaiter.Distribute(packet);

                        switch (packet.Type)
                        {
                            case MessageType.GET_ROOMS:
                                
                                List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>
                                    (JObject.Parse(packet.Body)["rs"].ToString());
                                Console.WriteLine("===================房间列表===================");
                                Console.WriteLine("ID\t房间名\t描述\t房主\t房客\t游戏中");
                                foreach (Room room in rooms)
                                    Console.WriteLine(room);
                                break;
                            case MessageType.CREATE:
                                Console.WriteLine($"创建成功，新房间ID: {packet.Body}");
                                TestingData.id = int.Parse(packet.Body);
                                break;
                            case MessageType.JOIN:
                                if (TestingData.isHost)
                                {
                                    Player guest = JsonConvert.DeserializeObject<Player>(packet.Body);
                                    Console.WriteLine($"玩家 {guest} 加入房间");
                                }
                                else
                                {
                                    Console.WriteLine($"加入成功，房间信息：");
                                    Console.WriteLine("ID\t房间名\t描述\t房主\t房客\t游戏中");
                                    Room room = JsonConvert.DeserializeObject<Room>(packet.Body);
                                    Console.WriteLine(room);
                                }
                                break;
                            case MessageType.LEAVE:
                                Console.WriteLine("对方离开房间");
                                break;
                            case MessageType.KICK_OUT:
                                if (TestingData.isHost)
                                {
                                    Console.WriteLine("对方被请离房间");
                                }
                                else
                                {
                                    Console.WriteLine("您被房主请离房间");
                                }
                                break;
                            case MessageType.READY:
                                if (TestingData.isHost)
                                {
                                    TestingData.isSP_Opp = !TestingData.isSP_Opp;
                                    if (TestingData.isSP_Opp)
                                        Console.WriteLine("对方进入准备状态");
                                    else
                                        Console.WriteLine("对方取消准备状态");
                                }
                                else
                                {
                                    TestingData.isSP_Our = !TestingData.isSP_Our;
                                    if (TestingData.isSP_Our)
                                        Console.WriteLine("进入准备状态");
                                    else
                                        Console.WriteLine("取消准备状态");
                                }
                                break;
                            case MessageType.STARTED:

                                if (TestingData.isHost)
                                {
                                    TestingData.isSP_Our = !TestingData.isSP_Our;
                                    if (TestingData.isSP_Our)
                                        Console.WriteLine("已进入开始状态，开始倒计时");
                                    else
                                        Console.WriteLine("取消开始状态");
                                }
                                else
                                {
                                    TestingData.isSP_Opp = !TestingData.isSP_Opp;
                                    if (TestingData.isSP_Opp)
                                        Console.WriteLine("房主已进入开始状态，开始倒计时");
                                    else
                                        Console.WriteLine("房主取消开始状态");
                                }
                                break;
                            case MessageType.COUNT_DOWN:
                                Console.WriteLine(packet.Body);
                                //开始关闭
                                if ("0".Equals(packet.Body))
                                {
                                    stop = false;
                                    Console.WriteLine("正在切换服务器....");
                                    TestingData.client.Duel(TestingData.id, TestingData.isHost);
                                }
                                break;
                            case MessageType.CHAT:
                                Console.WriteLine(packet.Body);
                                break;
                            case MessageType.WARRING:
                                R r = JsonConvert.DeserializeObject<R>(packet.Body);
                                Console.WriteLine($"错误：{RExceptionFactory.Generate(r).Message}");
                                break;
                        }
                        if (packet.Type != MessageType.COUNT_DOWN)
                            Console.WriteLine();
                    }
                }
                run = false;
            }
            catch (Exception ex)
            {
                DataPacket packet = new DataPacket(StatusCode.DISCONNECTED);
                Options.YGOWaiter.Distribute(packet);
                Console.WriteLine(ex.ToString());
            }

        }


    }
}
