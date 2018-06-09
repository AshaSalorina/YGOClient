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

        internal YgoSocket Socket
        {
            get
            {
                return socket;
            }

            set
            {
                socket = value;
            }
        }

        public RoomController(YgoSocket socket)
        {
            this.Socket = socket;
        }

        public void Chat(string message)
        {
            Socket.Send(message, MessageType.CHAT);
        }

        public void Leave()
        {
            Socket.Send("", MessageType.LEAVE);
        }

        public void ChangeStatus(bool isHost)
        {
            Socket.Send("", isHost ? MessageType.STARTED : MessageType.READY);
        }

        public void KickOut()
        {
            Socket.Send("", MessageType.KICK_OUT);
        }

        public void FingerGuess(FingerGuess finger)
        {
            Socket.Send(finger.ToString(), MessageType.FINGER_GUESS);
        }

    }
}
