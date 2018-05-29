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

        private YGOPDecoder decoder;

        private AutoResetEvent Event = new AutoResetEvent(false);

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

        public void Resume()
        {
            Event.Set();
        }

        public void Reset()
        {
            Event.Reset();
        }

        public void ReceiveMessage()
        {
            Stopwatch wacth = new Stopwatch();
            wacth.Start();

            while (true)
            {
                Event.WaitOne();
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
                        wacth.Restart();
                    }
                    Options.YGOWaiter.Distribute(packet);
                }
            }
        }


    }
}
