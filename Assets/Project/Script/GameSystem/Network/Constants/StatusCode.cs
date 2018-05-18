
namespace Egan.Constants
{
    public enum StatusCode
    {
        /// <summary>
        /// 正常
        /// </summary>
        OK = 2000,
        /// <summary>
        /// 房间密码错误
        /// </summary>
        INCORRECT = 4316,
        /// <summary>
        /// 房间已开始游戏
        /// </summary>
        PLAYING = 4381,
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
        FULL_ROOM = 4392
    }
}