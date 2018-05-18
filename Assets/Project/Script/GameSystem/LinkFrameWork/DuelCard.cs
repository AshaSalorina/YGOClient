using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYJ
{
    /// <summary>
    /// DuelCard类，继承自Card类
    /// </summary>
    public class DuelCard : Card
    {
        /// <summary>
        /// 卡牌名称副本, 否决值 ""
        /// </summary>
        private string copyName = "";
        /// <summary>
        /// 卡牌规则名称副本, 否决值 ""
        /// </summary>
        private string copyRuleName = "";
        /// <summary>
        /// 卡牌星级副本, 否决值 -1
        /// </summary>
        private int copyLevel = -1;
        /// <summary>
        /// 卡牌属性副本, 否决值 -1
        /// </summary>
        private int copyAttribute = -1;
        /// <summary>
        /// 卡牌种类副本, 否决值 -1
        /// </summary>
        private int copyType = -1;
        /// <summary>
        /// 卡牌攻击力副本, 否决值 -1
        /// </summary>
        private int copyAtk = -1;
        /// <summary>
        /// 卡牌守备力副本, 否决值 -1
        /// </summary>
        private int copyDef = -1;
        /// <summary>
        /// 卡牌效果文本副本, 否决值 ""
        /// </summary>
        private string copyEffectText = "";



        /// <summary>
        /// 卡牌所在区域
        /// </summary>
        private int field;
        /// <summary>
        /// 攻击次数
        /// </summary>
        private int attackNumber;
        /// <summary>
        /// 反转次数
        /// </summary>
        private int reversalNumber;

    }
}
