
namespace Egan.Constants
{
    public enum StatusCode
    {
        /// <summary>
        /// 被列入黑名单
        /// </summary>
        BLACKLISTED = 4314,
        /// <summary>
        /// 房间密码错误
        /// </summary>
        INCORRECT = 4316,
        /// <summary>
        /// 房客未准备
        /// </summary>
        UNPREPARED = 4382,
        /// <summary>
        /// 房间已解散
        /// </summary>
        DISMISSED = 4383,
        /// <summary>
        /// 大厅已满
        /// </summary>
        FULL_LOBBY = 4391,
        /// <summary>
        /// 房间已满
        /// </summary>
        FULL_ROOM = 4392,
        /// <summary>
        /// 服务器内部错误
        /// </summary>
        INTERNAL_SERVER_ERROR = 5000,
        /// <summary>
        /// 玩家已在其他房间
        /// </summary>
        BE_IN_ANOTHER = 6008,
        /// <summary>
        /// 玩家不在本房间
        /// </summary>
        NOT_IN_HERE = 6012,
        /// <summary>
        /// 玩家无权限
        /// </summary>
        NO_ACCESS = 6024,
        
    }
}