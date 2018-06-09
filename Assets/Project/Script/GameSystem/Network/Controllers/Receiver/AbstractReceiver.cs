using Egan.Tools;
using System;
using System.Threading;

namespace Egan.Controllers
{
    abstract class AbstractReceiver
    {

        protected bool stop = false;

        protected bool run = true;

        protected YGOPDecoder decoder;

        Thread thread;

        public void Start()
        {
            run = true;
            thread = new Thread(ReceiveMessage);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Close()
        {
            stop = true;
        }

        public abstract void ReceiveMessage();


    }
}
