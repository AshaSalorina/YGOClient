﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Asha.Tools;
using Egan.Models;
using Egan.Controllers;
using System;

namespace Asha
{
    /// <summary>
    /// Save All
    /// </summary>
    public class Options
    {

        #region 全局字段(游戏配置)
        /// <summary>
        /// 全局-背景图片的地址（URL）
        /// </summary>
        public static string backgroundURL = "";

        /// <summary>
        /// 全局-音量大小
        /// </summary>
        public static int audioLaude;

        /// <summary>
        /// 主客机判定
        /// 请使用RoomInfo.isMaster
        /// </summary>
        [Obsolete]
        public static bool isRoomMaster;


        #endregion

        #region 全局路径(视为常量)

        /// <summary>
        /// 全局-事件系统
        /// </summary>
        public static GameObject EventSystem;

        /// <summary>
        /// 全局-主画布
        /// </summary>
        public static GameObject MainCanvas;
        /// <summary>
        /// 全局-标题和背景区
        /// </summary>
        public static GameObject MainScence;
        /// <summary>
        /// 全局-主标题菜单
        /// </summary>
        public static GameObject Menu;
        /// <summary>
        /// 全局-游戏大厅
        /// </summary>
        public static GameObject GameCenter;
        /// <summary>
        /// 全局-卡组编辑与查询
        /// </summary>
        public static GameObject CardsSet;
        /// <summary>
        /// 全局-2d游戏界面
        /// </summary>
        public static GameObject Game2D;
        /// <summary>
        /// 全局-设置界面
        /// </summary>
        public static GameObject Optionpl;
        /// <summary>
        /// 全局-3d游戏盘
        /// </summary>
        public static GameObject GameArea;

        /// <summary>
        /// 准备用的房间
        /// </summary>
        public static GameObject Room;

        /// <summary>
        /// 声音源
        /// </summary>
        public static GameObject AudioSource;
        #endregion

        #region Prefabs

        public static GameObject warrningBox;

        #endregion

        #region 消息机对象
        /// <summary>
        /// 服务器被动等待队列分发器
        /// </summary>
        public static YGOTrig YGOWaiter;

        #endregion

        #region 游戏大厅下的字段(GameCenter)
        /// <summary>
        /// 游戏大厅-被选中的房间的编号
        /// </summary>
        public static int selectedRoom;
        #endregion

        #region PlayerInfo

        public static Player player;

        #endregion

        #region NetWork

        public static NetworkClient client;

        #endregion
    }
}


