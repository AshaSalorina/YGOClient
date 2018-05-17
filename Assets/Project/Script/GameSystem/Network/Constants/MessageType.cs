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
        /// 聊天信息
        /// </summary>
        CHAT = 0x1,
        /// <summary>
        /// 操作信息
        /// </summary>
        OPERATE = 0x4,
        /// <summary>
        /// 加入房间
        /// </summary>
        JOIN = 0x8,
        /// <summary>
        /// 离开房间
        /// </summary>
        LEAVE = 0x0,
        /// <summary>
        /// 进入准备状态
        /// </summary>
        PREPARED = 0x0,
        /// <summary>
        /// 进入开始状态
        /// </summary>
        STARTED = 0x0,
        /// <summary>
        /// 校验卡组
        /// </summary>
        VERITY = 0x0,
    }
}
