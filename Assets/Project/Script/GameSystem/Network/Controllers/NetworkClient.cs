using Egan.Exceptions;
using Egan.Models;
using Egan.Constants;
using System.Collections.Generic;
using System.Net.Sockets;
using System;
using System.Threading;
using Egan.Controllers;
using Asha;
using Egan.Tools;
using System.Runtime.Remoting.Messaging;
using HYJ.Models;

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
        private static YgoSocket socket;

        private static YGOPDecoder decoder;

        private LobbyController lobbyController;

        private RoomController roomController;

        private GameController gameController;

        private AbstractReceiver receiver;

        public NetworkClient()
        {
            

            try
            {
                socket = new YgoSocket();
                lobbyController = new LobbyController(socket);
                socket.Start(RemoteAddress.LOBBY_IP, RemoteAddress.LOBBY_PORT);
                decoder = new YGOPDecoder(socket);
                receiver = new LobbyReceiver(decoder);
                receiver.Start();
            }
            catch(Exception e)
            {
                throw new RException(e.ToString());
            }
        }

        /// <summary>
        /// 获取房间列表信息
        /// </summary>
        /// <returns>房间列表</returns>
        public void GetRooms()
        {
            lobbyController.GetRoomList();
        }

        /// <summary>
        /// 创建新房间
        /// </summary>
        /// <param name="room">新房间信息</param>
        /// <returns>处理后的服务器响应状态</returns>
        public void CreateRoom(Room room)
        {
            if (roomController == null)
                roomController = new RoomController(socket);
            lobbyController.CreateRoom(room);
        }

        /// <summary>
        /// 加入房间
        /// </summary>
        /// <param name="id">房间id</param>
        /// <param name="guest">房客信息</param>
        /// <param name="password">密码</param>
        /// <returns>目标房间</returns>
        public void JoinRoom(int id, Egan.Models.Player guest, string password = "")
        {
            if (roomController == null)
                roomController = new RoomController(socket);
            lobbyController.JoinRoom(id, guest, password);

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

        /// <summary>
        /// 改变开始\准备状态
        /// </summary>
        /// <param name="isHost">是否为房主</param>
        public void ChangeStatus(bool isHost)
        {
            roomController.ChangeStatus(isHost);
        }

        /// <summary>
        /// 踢出房间
        /// </summary>
        public void KickOut()
        {
            roomController.KickOut();
        }

        /// <summary>
        /// 决斗开始
        /// </summary>
        /// <param name="id">房间ID</param>
        /// <param name="isHost">是否为房主</param>
        public void Duel(int id, bool isHost)
        {
            try
            {
                ShutDownGracefully();

                while (socket.isConnected());

                socket = new YgoSocket();

                decoder = new YGOPDecoder(socket);

                roomController.Socket = socket;
                lobbyController.Socket = socket;

                socket.Start(RemoteAddress.DUEL_IP, RemoteAddress.DUEL_PORT);

                receiver = new DuelReceiver(decoder);
                receiver.Start();

                gameController = new GameController(socket);

                //执行游戏开始前的准备工作
                gameController.JoinGame(id, isHost);
            }
            catch(Exception ex)
            {
                throw new RException(ex.Message);
            }
        }

        /// <summary>
        /// 发送卡组
        /// </summary>
        /// <param name="deck">卡片ID集</param>
        public void SendDeck(List<int> deck)
        {
            gameController.SendDeck(deck);
        }

        /// <summary>
        /// 猜拳
        /// </summary>
        /// <param name="finger">出拳</param>
        public void FingerGuess(FingerGuess finger)
        {
            gameController.Finger(finger);
        }

        /// <summary>
        /// 玩家操作
        /// </summary>
        /// <param name="message">操作消息</param>
        public void Operate(Message message)
        {
            gameController.Operate(message);
        }

        /// <summary>
        /// 优雅关闭
        /// </summary>
        public void ShutDownGracefully()
        {
            receiver.Close();
            socket.ShutdownGracefully();
            while (socket.isConnected()) ;
            
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
