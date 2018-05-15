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
    /// 处理来自服务器响应状态的异常
    /// </summary>
    public class RExceptionHandler
    {
        public static RException R(int code)
        {
            string msg;

            switch (code)
            {
                case 4000: msg = "房间信息缺失"; break;
                case 4316: msg = "房间密码错误"; break;
                case 4317: msg = "当前证书已过期"; break;
                case 4381: msg = "房间已开始游戏"; break;
                case 4382: msg = "房客未进入准备状态"; break;
                case 4383: msg = "房间已解散"; break;
                case 4391: msg = "游戏大厅的房间容量已满"; break;
                case 4392: msg = "房间的玩家容量已满"; break;
                default: msg = "发生未知错误"; break;
            }

            return new RException(msg);
        }
    }
}
