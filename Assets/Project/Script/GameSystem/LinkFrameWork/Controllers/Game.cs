using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYJ.Models;
using System.Reflection;

namespace HYJ.Controllers
{
    /// <summary>
    /// 游戏主类
    /// </summary>
    public class Game
    {
        /// <summary>
        /// 本机玩家 身份
        /// </summary>
        public ControllerEnum localPlayer;
        /// <summary>
        /// 决斗玩家
        /// </summary>
        public Player[] players;
        /// <summary>
        /// 决斗卡组
        /// </summary>
        public List <DuelCard>[] decks;
        /// <summary>
        /// 回合数，默认值 1
        /// </summary>
        public int round = 1;
        /// <summary>
        /// 回合阶段
        /// 1：准备阶段
        /// 2：抽卡阶段
        /// 3：主阶段1
        /// 4：战斗阶段
        /// 5：主阶段2
        /// 6：结束阶段
        /// </summary>
        public int stage;
        /// <summary>
        /// 战斗阶段
        /// 0：未进入
        /// 1：开始步骤
        /// 2：攻击宣言
        /// 3：计算步骤
        /// 4：结束步骤
        /// </summary>
        public int battle;
        /// <summary>
        /// 当前回合玩家
        /// </summary>
        public ControllerEnum currentPlayer;
        /// <summary>
        /// 游戏是否结束，默认值 false
        /// </summary>
        public bool isGameOver = false;
        /// <summary>
        /// 游戏是否正在连锁,默认false
        /// </summary>
        public bool isChain;
        /// <summary>
        /// 系统操作
        /// </summary>
        public string gameAction;

        public List<Chain> chains;//缺少操作类

        /// <summary>
        /// 怪兽区域卡集合
        /// </summary>
        public List<DuelCard>[] monsterField;
        /// <summary>
        /// 魔法陷阱区域卡集合
        /// </summary>
        public List<DuelCard>[] spellorTrapField;
        /// <summary>
        /// 手牌区域卡集合
        /// </summary>
        public List<DuelCard>[] handField;
        /// <summary>
        /// 墓地区域卡集合
        /// </summary>
        public List<DuelCard>[] cemeteryField;
        /// <summary>
        /// 卡组区域卡集合
        /// </summary>
        public List<DuelCard>[] mainDeckField;

        /// <summary>
        /// 获得某个玩家场上怪兽卡数量
        /// </summary>
        /// <param name="controllerEnum">玩家身份</param>
        public int GetNumOfMonsterField(ControllerEnum controllerEnum)
        {
            int num = 0;
            foreach (DuelCard c in this.decks[int.Parse(controllerEnum.ToString())])
            {
                if (c.field == FieldEnum.Monster)
                {
                    num++;
                }
            }

            return num;
        }
        /// <summary>
        /// 获得某个玩家场上魔法卡&陷阱卡数量
        /// </summary>
        /// <param name="controllerEnum">玩家身份</param>
        public int GetNumOfSpellorTrapField(ControllerEnum controllerEnum)
        {
            int num = 0;
            foreach (DuelCard c in this.decks[int.Parse(controllerEnum.ToString())])
            {
                if (c.field == FieldEnum.SpellorTrap)
                {
                    num++;
                }
            }

            return num;
        }

        /// <summary>
        /// Game构造函数
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="players"></param>
        /// <param name="first"></param>
        public Game(List<Card>[] cards, object[] players, ControllerEnum first)
        {
            //balabala
        }

        ///// <summary>
        ///// 进入下个回合
        ///// </summary>
        //public void NextRound()
        //{
        //    this.round++;//回合数增加
        //    this.stage = 1;//准备阶段
        //    if (this.currentPlayer == ControllerEnum.HouseOwner)//交换回合控制者
        //    {
        //        this.currentPlayer = ControllerEnum.Tenant;
        //    }
        //    else
        //    {
        //        this.currentPlayer = ControllerEnum.HouseOwner;
        //    }
        //    //其余初始化 待做
        //}
        ///// <summary>
        ///// 进入下个阶段
        ///// </summary>
        //public void NextStage()
        //{
        //    this.stage++;
        //    if (this.stage == 4)
        //    {
        //        this.battle = 1;//进入战斗阶段 开始步骤
        //    }
        //    if (stage > 4)
        //    {
        //        this.battle = 0;//初始化战斗步骤
        //    }
        //}
        ///// <summary>
        ///// 下一个战斗步骤
        ///// </summary>
        //public void NextBatle()
        //{
        //    this.battle++;
        //}
        ///// <summary>
        ///// 结束战斗阶段
        ///// </summary>
        //public void EndBattle()
        //{
        //    this.battle = 4;//进入结束步骤
        //}
        ///// <summary>
        ///// 结束回合
        ///// </summary>
        //public void EndRound()
        //{
        //    this.stage = 6;//进入结束阶段
        //}

    }
}
