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
        /// 创建房间
        /// </summary>
        CREATE = 0x1,
        /// <summary>
        /// 玩家加入房间
        /// </summary>
        JOIN = CREATE << 1,
        /// <summary>
        /// 玩家离开房间
        /// </summary>
        LEAVE = JOIN << 1,
        /// <summary>
        /// 踢出房间
        /// </summary>
        KICK_OUT = LEAVE << 1,
        /// <summary>
        /// 玩家进入准备状态
        /// </summary>
        PREPARED = LEAVE << 1,
        /// <summary>
        /// 玩家进入开始状态
        /// </summary>
        STARTED = PREPARED << 1,
        /// <summary>
        /// 请玩家开始倒计时
        /// </summary>
        COUNT_DOWN = STARTED << 1,
        /// <summary>
        /// 校验客户端文件完整性
        /// </summary>
        VERITY = COUNT_DOWN << 1,
        /// <summary>
        /// 发送卡牌
        /// </summary>
        DECK = VERITY << 1,
        /// <summary>
        /// 猜拳消息
        /// </summary>
        FINGER_GUESS = DECK << 1,
        /// <summary>
        /// 聊天信息
        /// </summary>
        CHAT = FINGER_GUESS << 1,
        /// <summary>
        /// 操作信息
        /// </summary>
        OPERATE = CHAT << 1,
        /// <summary>
        /// 退出游戏
        /// </summary>
        EXIT = DECK << 1,
        /// <summary>
        /// 服务器发出警告信息
        /// </summary>
        WARRING = EXIT << 1
    }
}
