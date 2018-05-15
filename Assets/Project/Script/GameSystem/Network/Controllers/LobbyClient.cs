
using Egan.Models;
using Egan.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Egan.Cotrollers
{
    /// <summary>
    /// 游戏大厅客户端类
    /// </summary>
    public class LobbyClient
    {

        private string URL = "http://localhost:8844/";

        public LobbyClient(){}

        /// <summary>
        /// 获取房间列表
        /// </summary>
        /// <param name="max">最大房间数</param>
        /// <returns>房间列表</returns>
        public List<Room> GetRoomList(ref int max)
        {
            string jsonText = HttpWebWrapper.Get(URL);
            var jobj = JObject.Parse(jsonText);
            max = int.Parse(jobj["mx"].ToString());

            List<Room> rooms = null;

            try{
                rooms = JsonConvert.DeserializeObject<List<Room>>(jobj["rm"].ToString());
            }
            catch(NullReferenceException ex)
            {
                //ex.ToString();
            }

            return rooms;
        }
    }
}
