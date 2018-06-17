using Egan.Constants;
using Egan.Tools;
using System;

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
        public static RException Generate(R r)
        {
            string msg;

            StatusCode code = (StatusCode)r.Code;

            switch (code)
            {
                case StatusCode.INCORRECT: msg = "房间密码错误"; break;
                case StatusCode.UNPREPARED: msg = "房客未进入准备状态"; break;
                case StatusCode.DISMISSED: msg = "房间已解散"; break;
                case StatusCode.FULL_LOBBY: msg = "游戏大厅已满"; break;
                case StatusCode.FULL_ROOM: msg = "房间已满员"; break;
                case StatusCode.BLACKLISTED:
                    msg = "本机已被列入黑名单";
                    break;
                case StatusCode.INTERNAL_SERVER_ERROR:
                    msg = "服务器内部错误";
                    break;
                case StatusCode.BE_IN_ANOTHER:
                    msg = "您已在其他房间";
                    break;
                case StatusCode.NOT_IN_HERE:
                    msg = "您不在此房间内";
                    break;
                case StatusCode.NO_ACCESS:
                    msg = "您无权执行此操作";
                    break;
                default: msg = "未知错误"; break;
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
            if (YGOP.TIME_OUT > usedTime)
                return new RException("网络连接失败，请检查您的网络情况");
            else
                return new RException("服务器繁忙，请耐心等待");
        }

        public static RException Generate(Exception e)
        {
            return new RException(e.Message, e);
        }
    }
}
