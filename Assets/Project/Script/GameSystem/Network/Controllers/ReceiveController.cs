using System.Diagnostics;
using Asha;
using Asha.Tools;
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

        public void ReceiveMessage()
        {
            Stopwatch wacth = new Stopwatch();
            wacth.Start();

            while (!stop)
            {
                if (wacth.ElapsedMilliseconds > YGOP.TIME_OUT)
                    throw RExceptionFactory.Generate(wacth.ElapsedMilliseconds);
                if (decoder.ReceivePacket())
                {
                    DataPacket packet = decoder.ParsePacket();
                    YgoSocket.PrintPacket(packet);

                    if (packet.Type == MessageType.WARRING)
                    {
                        R r = JsonConvert.DeserializeObject<R>(packet.Body);
                        WarningBox.Show(RExceptionFactory.Generate(r).ToString());
                    }
                    YGOTrig.Distribute(packet);
                }
            }
        }

        public bool Stop
        {
            get
            {
                return stop;
            }

            set
            {
                stop = value;
            }
        }
    }
}
