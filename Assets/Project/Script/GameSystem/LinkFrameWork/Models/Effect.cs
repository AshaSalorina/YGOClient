using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYJ.Models
{
    /// <summary>
    /// 卡牌效果类
    /// </summary>
    public class Effect
    {
        /// <summary>
        /// 效果属于DuelCard对象,默认值 null
        /// </summary>
        public DuelCard card = null;
        /// <summary>
        /// 是否能发动效果,默认值 false
        /// </summary>
        public bool enableLuanch = false;
        /// <summary>
        /// 效果名,默认值 ""
        /// </summary>
        public string name = "";
        /// <summary>
        /// 回合发动次数,否决之值 -1
        /// </summary>
        public int num = -1;
        /// <summary>
        /// 回合发动次数副本,否决之值 -1
        /// </summary>
        public int copyNum = -1;
        /// <summary>
        /// 效果速度, 否决值 -1
        /// </summary>
        public int speed = -1;
        /// <summary>
        /// 是否是操作方法,默认值 false
        /// </summary>
        public bool isAction = false;
        /// <summary>
        /// 是否进入连锁,默认值 false
        /// </summary>
        public bool isInChain = false;
        /// <summary>
        /// 是否是主动触发效果,默认值 false
        /// </summary>
        public bool isActive = false;
        /// <summary>
        /// 适用游戏回合阶段,默认值 null
        /// </summary>
        public int[] gameStage = null;
        /// <summary>
        /// 适用游戏战斗阶段，0代表不在战斗阶段
        /// </summary>
        public int[] gameBattle = null;
        /// <summary>
        /// 适用于什么操作后，“”代表没有前置操作
        /// </summary>
        public string afterAction = "";
        /// <summary>
        /// 目标卡牌数量,默认值 0
        /// </summary>
        public int targetNum = 0;
        /// <summary>
        /// 目标卡牌条件,默认值 null
        /// </summary>
        public object[][] targetCondition = null;
        /// <summary>
        /// 效果参数列表, [0]是效果方法名/操作方法名,默认值 null
        /// </summary>
        public string[] effectParameter = null;

        /// <summary>
        /// Effect类构造函数
        /// </summary>
        /// <param name="c">效果属于的DuelCard实例对象</param>
        public Effect(DuelCard c)
        {
            this.card = c;
        }
        /// <summary>
        /// Effect类构造函数
        /// </summary>
        public Effect()
        {
            //无
        }
    }
 
}
