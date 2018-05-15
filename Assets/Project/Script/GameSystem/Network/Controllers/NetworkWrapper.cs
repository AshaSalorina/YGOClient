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

        /// <summary>
        /// 最大房间数
        /// </summary>
        private int maxRoomNum;

        public NetworkWrapper() { }

        /// <summary>
        /// 获取房间列表信息
        /// </summary>
        /// <returns>房间列表</returns>
        public List<Room> GetRoom() {
            if (lobbyClient == null)
                lobbyClient = new LobbyClient();
            
            return lobbyClient.GetRoomList(ref maxRoomNum);
        }

        public int MaxRoomNum
        {
            get
            {
                return maxRoomNum;
            }

            set
            {
                maxRoomNum = value;
            }
        }
    }


}
