
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
        Incorrect = 4316,
        /// <summary>
        /// Token无效
        /// </summary>
        InvalidToken = 4317,
        /// <summary>
        /// 房间已开始游戏
        /// </summary>
        Playing = 4381,
        /// <summary>
        /// 房客未准备
        /// </summary>
        Unprepared = 4382,
        /// <summary>
        /// 房间已解散
        /// </summary>
        Dimissed = 4383,
        /// <summary>
        /// 大厅已满
        /// </summary>
        FullLobby = 4391,
        /// <summary>
        /// 房间已满
        /// </summary>
        FullRoom = 4392
    }
}