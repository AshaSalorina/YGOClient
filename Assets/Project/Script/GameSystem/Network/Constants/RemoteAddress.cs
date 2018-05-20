using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Constants
{
    /// <summary>
    /// 各个远程主机的地址常量集合
    /// </summary>
    public class RemoteAddress
    {
        /// <summary>
        /// 游戏大厅http服务器的URL(获取房间列表)
        /// </summary>
        public static readonly string LOBBY_URL_ROOM = "";
        /// <summary>
        /// 游戏大厅http服务器的URL(获取公告信息)
        /// </summary>
        public static readonly string LOBBY_URL_BULLETIN = "";

        /// <summary>
        /// 决斗tcp服务器的IP地址
        /// </summary>
        public static readonly string DUEL_IP = "127.0.0.1";
        /// <summary>
        /// 决斗tcp服务器的端口
        /// </summary>
        public static readonly int DUEL_PORT = 0;

        /// <summary>
        /// 版本更新服务器的IP地址
        /// </summary>
        public static readonly string VERSION_IP = "";
        /// <summary>
        /// 版本更新服务器的端口
        /// </summary>
        public static readonly int VERSION_PORT = 0;
    }
}
