using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Constants
{
    /// <summary>
    /// SOCKET消息类型枚举
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 接收到房间列表
        /// </summary>
        GET_ROOMS = 0x1,
        /// <summary>
        /// 创建房间成功
        /// </summary>
        CREATE = GET_ROOMS << 1,
        /// <summary>
        /// 加入房间成功
        /// </summary>
        JOIN = CREATE << 1,
        /// <summary>
        /// 对方离开房间
        /// </summary>
        LEAVE = JOIN << 1,
        /// <summary>
        /// 对方/我方被踢出房间
        /// </summary>
        KICK_OUT = LEAVE << 1,
        /// <summary>
        /// 对方进入准备状态(房主)
        /// 进入准备状态成功(房客)
        /// </summary>
        READY = KICK_OUT << 1,
        /// <summary>
        /// 进入开始状态成功(房主)
        /// 对方进入开始状态(房客)
        /// </summary>
        STARTED = READY << 1,
        /// <summary>
        /// 开始倒计时
        /// </summary>
        COUNT_DOWN = STARTED << 1,
        /// <summary>
        /// 接收到对方的卡组
        /// </summary>
        DECK = COUNT_DOWN << 1,
        /// <summary>
        /// 接收到猜拳结果
        /// </summary>
        FINGER_GUESS = DECK << 1,
        /// <summary>
        /// 接收到对方的聊天信息
        /// </summary>
        CHAT = FINGER_GUESS << 1,
        /// <summary>
        /// 接收到操作消息
        /// </summary>
        OPERATE = CHAT << 1,
        /// <summary>
        /// 对方退出游戏
        /// </summary>
        EXIT = OPERATE << 1,
        /// <summary>
        /// 接收到最新版本号
        /// </summary>
        GET_VERSION = EXIT << 1,
        /// <summary>
        /// 接收到公告板
        /// </summary>
        GET_BULLETIN = GET_VERSION << 1,
        /// <summary>
        /// 文件完整
        /// </summary>
        VERITY = GET_BULLETIN << 1,
        /// <summary>
        /// 接收到警告信息
        /// </summary>
        WARRING = VERITY << 1
    }
}
