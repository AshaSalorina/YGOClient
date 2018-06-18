using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYJ.Models
{
    /// <summary>
    /// 控制者枚举
    /// </summary>
    public enum ControllerEnum
    {
        /// <summary>
        /// 玩家1(房主),0
        /// </summary>
        HouseOwner,
        /// <summary>
        /// 玩家2(房客),1
        /// </summary>
        Tenant,
        /// <summary>
        /// 系统,2
        /// </summary>
        System
    }

    /// <summary>
    /// DuelCard所处区域枚举
    /// </summary>
    public enum FieldEnum
    {
        /// <summary>
        /// 主卡组区域
        /// </summary>
        MainDeck,
        /// <summary>
        /// 额外卡组区域
        /// </summary>
        ExtraDeck,
        /// <summary>
        /// 手牌区域
        /// </summary>
        Hand,
        /// <summary>
        /// 主怪兽区域
        /// </summary>
        Monster,
        /// <summary>
        /// 魔法陷阱区域
        /// </summary>
        SpellorTrap,
        /// <summary>
        /// 场地魔法卡区域
        /// </summary>
        FieldSpell,
        /// <summary>
        /// 墓地区域
        /// </summary>
        Cemetery,
        /// <summary>
        /// 除外区域
        /// </summary>
        Exception
    }

    /// <summary>
    /// DuelCard状态枚举
    /// </summary>
    public enum StateEnum
    {
        /// <summary>
        /// 仅自知状态
        /// </summary>
        Cover,
        /// <summary>
        /// 展示状态
        /// </summary>
        Show,
        /// <summary>
        /// 未知状态
        /// </summary>
        Deck,
        /// <summary>
        /// 表侧攻击
        /// </summary>
        SideAttack,
        /// <summary>
        /// 表侧守备
        /// </summary>
        SideDefence,
        /// <summary>
        /// 里侧守备
        /// </summary>
        BackDefence,
        /// <summary>
        /// 后场放置
        /// </summary>
        BackSet
    }

    /// <summary>
    /// Effect类型枚举
    /// </summary>
    public enum EffectEnum
    {
        /// <summary>
        /// 通常召唤
        /// </summary>
        NormalSummon,
        /// <summary>
        /// 特殊召唤
        /// </summary>
        SpecialSummon,
        /// <summary>
        /// 抽卡
        /// </summary>
        DrawCard,
        /// <summary>
        /// 弃卡
        /// </summary>
        AbandanCard,
        /// <summary>
        /// 效果破坏
        /// </summary>
        EffectDestroy,
        /// <summary>
        /// 战斗破坏
        /// </summary>
        BattleDestroy,

    }
    /// <summary>
    /// Message类型枚举
    /// </summary>
    public enum MessageEnum
    {
        /// <summary>
        /// 系统消息
        /// </summary>
        SystemMessage,
        /// <summary>
        /// 效果消息
        /// </summary>
        EffectMessage,
        /// <summary>
        /// 操作消息
        /// </summary>
        ActionMessage,
        /// <summary>
        /// 回合消息
        /// </summary>
        RoundMessage
    }
}
