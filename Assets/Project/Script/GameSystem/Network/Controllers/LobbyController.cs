using Egan.Constants;
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
            this.socket = socket;
            try
            {
                socket.Start(RemoteAddress.LOBBY_IP, RemoteAddress.LOBBY_PORT);
            }
            catch
            {
                throw new RException("网络连接失败");
            }
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

        /// <summary>
        /// 获取房间列表
        /// </summary>
        /// <param name="max">最大房间数</param>
        /// <returns>房间列表</returns>
        public List<Room> GetRoomList(ref int max)
        {
            List<Room> rooms = null;

            try
            {
                //发送获取房间列表请求
                socket.Send("", MessageType.GET_ROOMS);
                DataPacket packet;

                //等待服务器的响应
                packet = socket.ReceivePacket();

                string jsonText = packet.Body;
                var jobj = JObject.Parse(jsonText);
                max = int.Parse(jobj["mx"].ToString());
                rooms = JsonConvert.DeserializeObject<List<Room>>(jobj["rm"].ToString());

            }
            catch(NullReferenceException){}
            catch (RException rex)
            {
                throw rex;
            }

            return rooms;
        }

        /// <summary>
        /// 创建新房间
        /// </summary>
        /// <param name="room">新房间信息</param>
        /// <returns>新房间ID</returns>
        public int CreateRoom(Room room)
        {
            int id = 0;

            String json = JsonConvert.SerializeObject(room);

            //发送创建房间请求
            socket.Send(json, MessageType.CREATE);
            DataPacket packet;

            //等待服务器的响应
            packet = socket.ReceivePacket();

            id = int.Parse(packet.Body);

            return id;
        }

        public Room JoinRoom(int id, Player guest, String password)
        {
            Dictionary<string, object> temp = new Dictionary<string, object>();

            temp.Add("id", id);
            temp.Add("gs", guest);
            temp.Add("pw", password);

            String json = JsonConvert.SerializeObject(temp);

            socket.Send(json, MessageType.JOIN);

            DataPacket packet;

            packet = socket.ReceivePacket();

            Room room = JsonConvert.DeserializeObject<Room>(packet.Body);

            return room;
        }
        
    }
}
