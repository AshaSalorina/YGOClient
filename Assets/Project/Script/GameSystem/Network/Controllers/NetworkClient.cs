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

        private ReceiveController receiver;

        public NetworkClient()
        {
            lobbyController = new LobbyController(socket);

            try
            {
                socket.Start(RemoteAddress.LOBBY_IP, RemoteAddress.LOBBY_PORT);
                receiver = new ReceiveController(socket.Decoder);
                socket.StartReciver(receiver.ReceiveMessage);
            }
            catch
            {
                throw new RException("网络连接失败");
            }
        }

        /// <summary>
        /// 获取房间列表信息
        /// </summary>
        /// <returns>房间列表</returns>
        public List<Room> GetRooms()
        {
            receiver.Stop = false;
            List<Room> rooms =  lobbyController.GetRoomList(ref maxRoomNum);
            receiver.Stop = true;

            return rooms;
        }

        /// <summary>
        /// 创建新房间
        /// </summary>
        /// <param name="room">新房间信息</param>
        /// <returns>处理后的服务器响应状态</returns>
        public int CreateRoom(Room room)
        {
            receiver.Stop = true;
            if (roomController == null)
                roomController = new RoomController(socket);
            receiver.Stop = true;
            int id = lobbyController.CreateRoom(room);
            if (receiver == null)
                receiver = new ReceiveController(socket.Decoder);
            receiver.Stop = false;
            socket.StartReciver(receiver.ReceiveMessage);
            return id;
        }

        /// <summary>
        /// 加入房间
        /// </summary>
        /// <param name="id">房间id</param>
        /// <param name="guest">房客信息</param>
        /// <param name="password">密码</param>
        /// <returns>目标房间</returns>
        public Room JoinRoom(int id, Player guest, string password = "")
        {
            if (roomController == null)
                roomController = new RoomController(socket);

            receiver.Stop = true;
            Room room = lobbyController.JoinRoom(id, guest, password);
            receiver.Stop = false;
            socket.StartReciver(receiver.ReceiveMessage);

            return room;
        }

        /// <summary>
        /// 发送聊天消息
        /// </summary>
        /// <param name="message">聊天消息</param>
        public void Chat(string message)
        {
            roomController.Chat(message);
        }

        /// <summary>
        /// 离开房间
        /// </summary>
        public void Leave()
        {
            roomController.Leave();
        }

        public void ShutDownGracefully()
        {
            socket.ShutdownGracefully();
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
