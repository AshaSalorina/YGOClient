﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Constants
{
    /// <summary>
    /// 猜拳常量
    /// </summary>
    public enum FingerGuess
    {
        /// <summary>
        /// 剪刀
        /// </summary>
        SCISSORS = 3,
        /// <summary>
        /// 石头
        /// </summary>
        ROCK = 2,
        /// <summary>
        /// 布
        /// </summary>
        PAPER = 1
}

    /// <summary>
    /// YGOP协议的其他常量
    /// </summary>
    public class YGOP
    {
        
        /// <summary>
        /// 版本所占字节数
        /// </summary>
        public static readonly int VERSION_LEN = 4;
        /// <summary>
        /// 消息类型所占字节数
        /// </summary>
        public static readonly int TYPE_LEN = 4;
        /// <summary>
        /// 魔数所占字节数
        /// </summary>
        public static readonly int MAGIC_LEN = 4;
        /// <summary>
        /// 消息体长度所占字节数
        /// </summary>
        public static readonly int LEN_LEN = 4;

        /// <summary>
        /// 版本的顺序
        /// </summary>
        public static readonly int VERSION_ORDER = 0;
        /// <summary>
        /// 类型的顺序
        /// </summary>
        public static readonly int TYPE_ORDER = VERSION_ORDER + 1;
        /// <summary>
        /// 魔数的顺序
        /// </summary>
        public static readonly int MAGIC_ORDER = TYPE_ORDER + 1;
        /// <summary>
        /// 消息体长度的顺序
        /// </summary>
        public static readonly int LEN_ORDER = MAGIC_ORDER + 1;
        /// <summary>
        /// 消息体的顺序
        /// </summary>
        public static readonly int BODY_ORDER = LEN_ORDER + 1;

        /// <summary>
        /// 版本的位置
        /// </summary>
        public static readonly int VERSION_POS = 0;
        /// <summary>
        /// 类型的位置
        /// </summary>
        public static readonly int TYPE_POS = VERSION_POS + VERSION_LEN;
        /// <summary>
        /// 魔数的位置
        /// </summary>
        public static readonly int MAGIC_POS = TYPE_POS + TYPE_LEN;
        /// <summary>
        /// 消息体长度的位置
        /// </summary>
        public static readonly int LEN_POS = MAGIC_POS + MAGIC_LEN;
        /// <summary>
        /// 消息体的位置
        /// </summary>
        public static readonly int BODY_POS = LEN_POS + LEN_LEN;


        /// <summary>
        /// 当前版本
        /// </summary>
        public static readonly float VERSION = 1.0F;
        /// <summary>
        /// 魔数
        /// </summary>
        public static readonly int MAGIC = 0x3cb;
        /// <summary>
        /// 数据包头的固定长度
        /// </summary>
        public static readonly int HEAD_LEN = VERSION_LEN + TYPE_LEN + MAGIC_LEN + LEN_LEN;
        /// <summary>
        /// 最大内容长度
        /// </summary>
        public static readonly int MAX_LEN = 1024;
        /// <summary>
        /// 协议的段数
        /// </summary>
        public static readonly int PART_COUNT = 5;

        /// <summary>
        /// 请求超时时间
        /// </summary>
        public static readonly int TIME_OUT = 10000;
    }
}
