using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Controllers
{
    class ReceiveController
    {
        private bool stop = false;

        public void ReceiveMessage()
        {

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
