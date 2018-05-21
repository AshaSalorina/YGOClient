using Egan.Constants;
using Egan.Exceptions;
using Egan.Models;
using Egan.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Controllers
{
    /// <summary>
    /// 房间控制器
    /// </summary>
    class RoomController
    {

        private YgoSocket socket;

        public RoomController(YgoSocket socket)
        {
            this.socket = socket;
        }

        /// <summary>
        /// 创建一个新房间
        /// </summary>
        /// <param name="room"></param>
        public void Create(Room room)
        {
            try
            {
                    
                String roomStr = JsonConvert.SerializeObject(room);

                DataPacket packet = new DataPacket(roomStr, MessageType.CREATE);

                byte[] roomBytes = YGOPEncoder.Encoder(packet);

                socket.Send(roomBytes);

            }
            catch(RException rex)
            {
                throw rex;
            }
            
        }
    }
}
