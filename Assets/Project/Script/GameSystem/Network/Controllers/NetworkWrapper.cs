using Egan.Cotrollers;
using Egan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Cotrollers
{
    /// <summary>
    /// 网络包装类
    /// </summary>
    public class NetworkWrapper
    {

        private LobbyClient lobbyClient;

        private DuelClient duelClient;

        public NetworkWrapper() {}

        public List<Room> GetRooms() {
            if (lobbyClient == null)
                lobbyClient = new LobbyClient();
            return lobbyClient.GetRoomList();
        }
    }
}
