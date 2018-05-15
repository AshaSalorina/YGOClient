using Egan.Cotrollers;
using Egan.Models;
using Egan.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Cotrollers
{
    /// <summary>
    /// 网络包装类
    /// 统一包装网络方法
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

        /// <summary>
        /// 创建新房间
        /// </summary>
        /// <param name="room">新房间信息</param>
        /// <returns>处理后的服务器响应状态</returns>
        public RHandler CreateRoom(Room room)
        {
            return new RHandler(lobbyClient.CreateRoom(room));
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
