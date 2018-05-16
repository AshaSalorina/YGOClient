using Egan.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Exceptions
{
    /// <summary>
    /// 自定义异常处理器
    /// </summary>
    public class RExceptionHandler
    {
        /// <summary>
        /// 处理来自服务器响应状态的异常
        /// </summary>
        /// <param name="code">服务器响应状态码</param>
        /// <returns></returns>
        public static RException Handle(StatusCode code)
        {
            string msg;

            switch (code)
            {
                case StatusCode.Incorrect: msg = "房间密码错误"; break;
                case StatusCode.Playing: msg = "房间已开始游戏"; break;
                case StatusCode.Unprepared: msg = "房客未进入准备状态"; break;
                case StatusCode.Dimissed: msg = "房间已解散"; break;
                case StatusCode.FullLobby: msg = "游戏大厅的房间容量已满"; break;
                case StatusCode.FullRoom: msg = "房间的玩家容量已满"; break;
                default: msg = "发生未知错误"; break;
            }

            return new RException(msg);
        }

        /// <summary>
        /// 处理网络连接异常
        /// </summary>
        /// <param name="timeOut"></param>
        /// <param name="usedTime"></param>
        /// <returns>异常</returns>
        public static RException Handle(int timeOut, double usedTime)
        {
            if (timeOut > usedTime)
                return new RException("网络连接失败，请检查您的网络情况");
            else
                return new RException("服务器故障，详情请查看公告");
        }
    }
}
