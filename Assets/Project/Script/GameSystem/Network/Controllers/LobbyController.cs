using Egan.Constants;
using Egan.Exceptions;
using Egan.Models;
using Egan.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Egan.Cotrollers
{
    /// <summary>
    /// 游戏大厅控制器
    /// 用于获取房间列表、最新版本号、公告等信息
    /// </summary>
    class LobbyController
    {
        /// <summary>
        /// 获取房间列表
        /// </summary>
        /// <param name="max">最大房间数</param>
        /// <returns>房间列表</returns>
        public static List<Room> GetRoomList(ref int max)
        {
            List<Room> rooms = null;

            try
            {
                string jsonText = HttpWebWrapper.Get(RemoteAddress.LOBBY_URL_ROOM);
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
        /// 获取最新的版本号
        /// </summary>
        /// <returns></returns>
        public static float GetVersion()
        {
            float version = 0f;
            try
            {
                string jsonText = HttpWebWrapper.Get(RemoteAddress.LOBBY_URL_VERSION);
                var jobj = JObject.Parse(jsonText);
                version = float.Parse(jobj["vs"].ToString());
            }
            catch (NullReferenceException) { }
            catch (RException rex)
            {
                throw rex;
            }
            return version;
        }

        /// <summary>
        /// 获取公告
        /// </summary>
        /// <returns></returns>
        public static String GetBulletin()
        {
            String buelltin = null;
            try
            {
                string jsonText = HttpWebWrapper.Get(RemoteAddress.LOBBY_URL_VERSION);
                var jobj = JObject.Parse(jsonText);
                buelltin = jobj["bt"].ToString();
            }
            catch (NullReferenceException) { }
            catch (RException rex)
            {
                throw rex;
            }
            return buelltin;
        }
        
    }
}
