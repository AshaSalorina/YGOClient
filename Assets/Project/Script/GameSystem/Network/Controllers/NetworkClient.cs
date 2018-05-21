using Egan.Exceptions;
using Egan.Models;
using Egan.Constants;
using System.Collections.Generic;

namespace Egan.Cotrollers
{
    /// <summary>
    /// 网络客户端类
    /// 包装所有网络方法
    /// </summary>
    public class NetworkClient
    {

        private LobbyController lobbyClient;

        private DuelClient duelClient;

        /// <summary>
        /// 最大房间数
        /// </summary>
        private int maxRoomNum;

        public NetworkClient()
        {
            lobbyClient = new LobbyController();
            duelClient = new DuelClient();
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
