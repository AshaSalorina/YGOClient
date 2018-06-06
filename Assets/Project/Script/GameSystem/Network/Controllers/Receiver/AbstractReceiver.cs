using Egan.Tools;
using System.Threading;

namespace Egan.Controllers
{
    abstract class AbstractReceiver
    {

        protected bool stop = false;

        protected YGOPDecoder decoder;

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

        public abstract void ReceiveMessage();


    }
}
