﻿using Egan.Constants;
using Egan.Controllers;
using Egan.Exceptions;
using Egan.Models;
using Egan.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace Egan.Controllers
{
    /// <summary>
    /// 游戏大厅控制器
    /// 用于获取房间列表、最新版本号、公告等信息
    /// </summary>
    class LobbyController
    {

        private YgoSocket socket;

        public LobbyController(YgoSocket socket)
        {
            this.Socket = socket;
            
        }

        internal YgoSocket YgoSocket
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

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

        /// <summary>
        /// 获取房间列表
        /// </summary>
        /// <param name="max">最大房间数</param>
        /// <returns>房间列表</returns>
        public void GetRoomList()
        {
            try
            {
                //发送获取房间列表请求
                Socket.Send("", MessageType.GET_ROOMS);
                DataPacket packet;

            }
            catch (RException rex)
            {
                throw rex;
            }

        }

        /// <summary>
        /// 创建新房间
        /// </summary>
        /// <param name="room">新房间信息</param>
        /// <returns>新房间ID</returns>
        public void CreateRoom(Room room)
        {
            String json = JsonConvert.SerializeObject(room);

            //发送创建房间请求
            Socket.Send(json, MessageType.CREATE);
        }

        public void JoinRoom(int id, Player guest, String password)
        {
            Dictionary<string, object> temp = new Dictionary<string, object>();

            temp.Add("id", id);
            temp.Add("gs", guest);
            temp.Add("pw", password);

            String json = JsonConvert.SerializeObject(temp);

            Socket.Send(json, MessageType.JOIN);

        }
        
    }
}
