using Egan.Exceptions;
using Egan.Models;
using Egan.Constants;
using System.Collections.Generic;
using System.Net.Sockets;
using System;
using System.Threading;
using Egan.Controllers;

namespace Egan.Controllers
{
    /// <summary>
    /// 网络客户端类
    /// 包装所有网络方法
    /// </summary>
    public class NetworkClient
    {

        /// <summary>
        /// 最大房间数
        /// </summary>
        private int maxRoomNum;

        /// <summary>
        /// 懒汉模式
        /// </summary>
        private YgoSocket socket = new YgoSocket();
        private LobbyController lobbyController;

        private RoomController roomController;

        public NetworkClient()
        {
            lobbyController = new LobbyController(socket);
        }

        /// <summary>
        /// 获取房间列表信息
        /// </summary>
        /// <returns>房间列表</returns>
        public List<Room> GetRooms() {
            try
            {
                return lobbyController.GetRoomList (ref maxRoomNum);
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
        public int CreateRoom(Room room)
        {
            try
            {
                return lobbyController.CreateRoom(room);
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

        public void ShutDownGracefully()
        {
            socket.ShutdownGracefully();
        }
    }


}
