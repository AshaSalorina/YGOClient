using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYJ.Models
{
    public class Player
    {
        /// <summary>
        /// 玩家ip
        /// </summary>
        private string ip;
        /// <summary>
        /// 玩家名称，默认 Dueler
        /// </summary>
        private string name = "Dueler";
        /// <summary>
        /// 玩家头像， 默认 “”
        /// </summary>
        private string headPic;
        /// <summary>
        /// 玩家身份， 默认 System
        /// </summary>
        private ControllerEnum status = ControllerEnum.System;
        /// <summary>
        /// 玩家LP值，默认规则 8000
        /// </summary>
        public int lifePint = 8000;
        /// <summary>
        /// 玩家失败，默认 false
        /// </summary>
        public bool failure = false;
        /// <summary>
        /// 回合通常召唤次数
        /// </summary>
        public int numNormalSummon;

        /// <summary>
        /// Player类构造函数
        /// </summary>
        /// <param name="pip">玩家ip</param>
        /// <param name="pname">玩家名称</param>
        /// <param name="phead">玩家头像</param>
        /// <param name="controller">玩家身份</param>
        public Player(string pip, string pname, string phead, ControllerEnum controller)
        {
            this.ip = pip;
            this.name = pname;
            this.headPic = phead;
            this.status = controller;
        }

        public string GetIp { get { return ip; } }
        public string GetName { get { return name; } }
        public string GetHeadPic { get { return headPic; } }
        public ControllerEnum GetStatus { get { return status; } }

        ///// <summary>
        ///// 可以发动卡牌权限，默认 true
        ///// </summary>
        //private bool enableLuanchCard = true;
        ///// <summary>
        ///// 可以发动魔法卡权限，默认 true
        ///// </summary>
        //private bool enableLuanchSpellCard = true;
        ///// <summary>
        ///// 可以发动陷阱卡权限，默认 true
        ///// </summary>
        //private bool enableLuanchTrapCard = true;

        ///// <summary>
        ///// 可以发动卡牌效果权限，默认 true
        ///// </summary>
        //private bool enableLuanchCardEffect = true;
        ///// <summary>
        ///// 可以发动怪兽卡效果权限，默认 true
        ///// </summary>
        //private bool enableLuanchMonsterEffect = true;
        ///// <summary>
        ///// 可以发动魔法卡效果权限，默认 true
        ///// </summary>
        //private bool enableLuanchSpellEffect = true;
        ///// <summary>
        ///// 可以发动陷阱卡效果权限，默认 true
        ///// </summary>
        //private bool enableLuanchTrapEffect = true;


        ///// <summary>
        ///// 可以通常召唤卡牌权限，默认 true
        ///// </summary>
        //private bool enableNormalSummon = true;
        ///// <summary>
        ///// 可以反转召唤卡牌权限，默认 true
        ///// </summary>
        //private bool enableFlipSummon = true;
        ///// <summary>
        ///// 可以上级召唤卡牌权限，默认 false
        ///// </summary>
        //private bool enableSuperiorSummon = true;
        ///// <summary>
        ///// 可以特殊召唤卡牌权限，默认 true
        ///// </summary>
        //private bool enableSpecialSummon = true;
        ///// <summary>
        ///// 可以融合召唤卡牌权限，默认 true
        ///// </summary>
        //private bool enableFusionSummon = true;
        ///// <summary>
        ///// 可以仪式召唤卡牌权限，默认 true
        ///// </summary>
        //private bool enableRitualSummon = true;

        ///// <summary>
        ///// 可以反转卡牌权限，默认 true
        ///// </summary>
        //private bool enableFlip = true;
        ///// <summary>
        ///// 可以覆盖卡牌权限，默认 true
        ///// </summary>
        //private bool enableSet = true;
        ///// <summary>
        ///// 可以改变卡牌表侧形式权限，默认 true
        ///// </summary>
        //private bool enableChangeFrom = true;



    }
}
