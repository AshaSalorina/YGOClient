using Egan.Exceptions;
using Egan.Models;
using Egan.Constants;
using System.Collections.Generic;

namespace Egan.Cotrollers
{
    /// <summary>
    /// 网络包装类
    /// 统一包装网络方法
    /// </summary>
    public class NetworkClient
    {
        /// <summary>
        /// 游戏大厅服务器的URL
        /// </summary>
        private string lobbyURL = "http://localhost:8844/";

        /// <summary>
        /// 决斗服务器的IP地址
        /// </summary>
        private string duelIP = "....";

        /// <summary>
        /// 决斗服务器的端口号
        /// </summary>
        private int duelPort = 0000;

        private LobbyClient lobbyClient;

        private DuelClient duelClient;

        /// <summary>
        /// 最大房间数
        /// </summary>
        private int maxRoomNum;

        public NetworkClient()
        {
            lobbyClient = new LobbyClient(lobbyURL);
            duelClient = new DuelClient(duelIP, duelPort);
        }

        /// <summary>
        /// 获取房间列表信息
        /// </summary>
        /// <returns>房间列表</returns>
        public List<Room> GetRooms() {
            try
            {
                return lobbyClient.GetRoomList(ref maxRoomNum);
            }catch(RException rex)
            {
                throw rex;
            }
            
        }

        /// <summary>
        /// 创建新房间
        /// </summary>
        /// <param name="room">新房间信息</param>
        /// <returns>处理后的服务器响应状态</returns>
        public void CreateRoom(Room room)
        {
            try
            {
                StatusCode code = (StatusCode)lobbyClient.CreateRoom(room).Code;
                if (code != StatusCode.OK)
                {
                    throw RExceptionHandler.Handle(code);
                }
            }
            catch (RException rex)
            {
                throw rex;
            }
            
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
