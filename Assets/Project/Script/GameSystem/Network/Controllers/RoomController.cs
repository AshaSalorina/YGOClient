using Egan.Constants;
using Egan.Exceptions;
using Egan.Models;
using Egan.Tools;
using Newtonsoft.Json;
using System;

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

        public void Chat(string message)
        {
            socket.Send(message, MessageType.CHAT);
        }

        public void Leave()
        {
            socket.Send("", MessageType.LEAVE);
        }

    }
}
