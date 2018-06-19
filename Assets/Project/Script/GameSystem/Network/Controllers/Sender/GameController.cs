using Egan.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYJ.Models;

namespace Egan.Controllers
{
    /// <summary>
    /// 游戏控制器
    /// 处理游戏开始前的准备工作和游戏开始后的操作
    /// </summary>
    class GameController
    {
        private static YgoSocket socket;

        public GameController(YgoSocket socket)
        {
            GameController.socket = socket;
        }

        public void JoinGame(int id, bool isHost)
        {
            socket.Send(id.ToString(), isHost ? MessageType.CREATE : MessageType.JOIN);
        }

        public void SendDeck(List<int> deck)
        {
            socket.Send(JsonConvert.SerializeObject(deck), MessageType.DECK);
        }

        public void Finger(FingerGuess finger)
        {
            socket.Send(((int)finger).ToString(), MessageType.FINGER_GUESS);
        }

        public void Operate(Message msg)
        {
            socket.Send(JsonConvert.SerializeObject(msg), MessageType.OPERATE);
        }

        //public void Operate()
    }
}
