using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Egan
{
    public class Room
    {
        private string id;
        private string rName;
        private string uName;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string RName
        {
            get
            {
                return rName;
            }

            set
            {
                rName = value;
            }
        }

        public string UName
        {
            get
            {
                return uName;
            }

            set
            {
                uName = value;
            }
        }
    }
}
