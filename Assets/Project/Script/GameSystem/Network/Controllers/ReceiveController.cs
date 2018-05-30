using System;
using System.Diagnostics;
using System.Threading;
using Asha;
using Egan.Constants;
using Egan.Exceptions;
using Egan.Models;
using Egan.Tools;
using Newtonsoft.Json;

namespace Egan.Controllers
{
    class ReceiveController
    {
        private bool stop = false;

        private YGOPDecoder decoder;


        public ReceiveController(YGOPDecoder decoder)
        {
            this.decoder = decoder;
        }

        public void Start()
        {
            Thread thread = new Thread(ReceiveMessage);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Close()
        {
            stop = true;
        }

        public void ReceiveMessage()
        {

            try
            {
                while (!stop)
                {
                    if (decoder.ReceivePacket())
                    {
                        DataPacket packet = decoder.ParsePacket();
                        YgoSocket.PrintPacket(packet);
                        //Options.YGOWaiter.Distribute(packet);

                        if (packet.Type == MessageType.WARRING)
                        {
                            R r = JsonConvert.DeserializeObject<R>(packet.Body);
                            
                        }
                    }
                }
            }catch(Exception ex)
            {
                DataPacket packet = new DataPacket(StatusCode.DISCONNECTED);
                Options.YGOWaiter.Distribute(packet);
            }
            
        }


    }
}
