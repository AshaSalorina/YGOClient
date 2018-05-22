using Egan.Constants;
using Egan.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Exceptions
{
    /// <summary>
    /// 自定义异常工厂
    /// </summary>
    public class RExceptionFactory
    {
        /// <summary>
        /// 根据服务器响应状态生成异常
        /// </summary>
        /// <param name="code">服务器响应状态码</param>
        /// <returns></returns>
        public static RException Generate(StatusCode code)
        {
            string msg;

            switch (code)
            {
                case StatusCode.INCORRECT: msg = "房间密码错误"; break;
                case StatusCode.PLAYING: msg = "房间已开始游戏"; break;
                case StatusCode.UNPREPARED: msg = "房客未进入准备状态"; break;
                case StatusCode.DISMISSED: msg = "房间已解散"; break;
                case StatusCode.FULL_LOBBY: msg = "游戏大厅的房间容量已满"; break;
                case StatusCode.FULL_ROOM: msg = "房间的玩家容量已满"; break;
                default: msg = "发生未知错误"; break;
            }

            return new RException(msg);
        }

        /// <summary>
        /// 根据请求超时时间生成异常
        /// </summary>
        /// <param name="usedTime">当前用时</param>
        /// <returns>异常</returns>
        public static RException Generate(double usedTime)
        {
            if (ProtocolConstant.TIME_OUT > usedTime)
                return new RException("网络连接失败，请检查您的网络情况");
            else
                return new RException("服务器故障，详情请查看公告");
        }

        public static RException Generate(Exception e)
        {
            return new RException(e.Message, e);
        }
    }
}
