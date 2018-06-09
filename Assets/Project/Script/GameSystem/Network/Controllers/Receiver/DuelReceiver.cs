using Asha;
using Egan.Constants;
using Egan.Exceptions;
using Egan.Models;
using Egan.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Egan.Controllers
{
    class DuelReceiver : AbstractReceiver
    {

        public DuelReceiver(YGOPDecoder decoder)
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
                        Options.YGOWaiter.Distribute(packet);
                        switch (packet.Type)
                        {
                            case MessageType.GET_ROOMS:
                                List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>
                                    (JObject.Parse(packet.Body)["rs"].ToString());
                                Console.WriteLine("===================房间列表===================");
                                Console.WriteLine("ID\t房间名\t描述\t房主\t房客");
                                foreach (Room room in rooms)
                                    Console.WriteLine(room);
                                break;
                            case MessageType.JOIN:
                                Console.WriteLine("已切换到决斗服务器");
                                
                                break;
                            case MessageType.LEAVE:
                                Console.WriteLine("对方离开游戏");
                                break;
                            case MessageType.CHAT:
                                Console.WriteLine(packet.Body);
                                break;
                            case MessageType.DECK:
                                List<float> deck = JsonConvert.DeserializeObject<List<float>>(packet.Body);
                                Console.WriteLine("对方的卡组：");
                                if (deck != null)
                                {
                                    Console.Write($"[{deck[0]}");
                                    deck.Remove(deck[0]);
                                    foreach (float card in deck)
                                        Console.Write($", {card}");
                                    Console.WriteLine("]");
                                }
                                    
                                       
                                break;
                            case MessageType.FINGER_GUESS:
                                string result = "猜拳结果错误";
                                switch (int.Parse(packet.Body))
                                {
                                    case 1: result = "我方胜利"; break;
                                    case 0: result = "平局"; break;
                                    case -1: result = "对方胜利"; break;
                                }
                                Console.WriteLine($"猜拳结果:{result}");
                                break;
                            case MessageType.OPERATE:
                                break;
                            case MessageType.WARRING:
                                R r = JsonConvert.DeserializeObject<R>(packet.Body);
                                Console.WriteLine($"错误：{RExceptionFactory.Generate(r).Message}");
                                break;
                        }
                    }
                }
                run = false;
            }
            catch (Exception ex)
            {
                DataPacket packet = new DataPacket(StatusCode.DISCONNECTED);
                //Options.YGOWaiter.Distribute(packet);
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
