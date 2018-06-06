using Asha;
using Egan.Constants;
using Egan.Models;
using Egan.Tools;
using Newtonsoft.Json;
using System;

namespace Egan.Controllers
{
    class DuelReceiver : AbstractReceiver
    {

        DuelReceiver(YGOPDecoder decoder)
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
                        YgoSocket.PrintPacket(packet);
                        Options.YGOWaiter.Distribute(packet);

                        if (packet.Type == MessageType.WARRING)
                        {
                            R r = JsonConvert.DeserializeObject<R>(packet.Body);
                        }
                        if (packet.Type == MessageType.JOIN)
                        {
                            packet.Type = MessageType.JOIN;
                        }
                    }
                }
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
