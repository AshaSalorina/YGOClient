using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using HYJ.Models;

namespace HYJ.Controllers
{
    /// <summary>
    /// 游戏规则值
    /// </summary>
    static public class Rule
    {
        ///// <summary>
        ///// 规则：玩家LP值 8000
        ///// </summary>
        //static public int playerLP = 8000;
        ///// <summary>
        ///// 规则：能连锁其他效果的最低速度 2
        ///// </summary>
        //static public int chainSpeed = 2;
        ///// <summary>
        ///// 规则：手牌上限 6
        ///// </summary>
        //static public int handNumMax = 6;
        ///// <summary>
        ///// 规则：回合抽卡阶段抽卡数 1
        ///// </summary>
        //static public int drawCardNum = 1;
        ///// <summary>
        ///// 规则：额外卡组卡牌数上限 15
        ///// </summary>
        //static public int extraDeckNumMax = 15;
        ///// <summary>
        ///// 规则：主卡组卡牌数上限 60
        ///// </summary>
        //static public int mainDeckNumMax = 60;
        ///// <summary>
        ///// 规则：主卡组手牌数下限 40
        ///// </summary>
        //static public int mainDeckNumMin = 40;
        ///// <summary>
        ///// 规则：上级召唤需要1只解放的最低级别 5
        ///// </summary>
        //static public int superiorSummonOne = 5;
        ///// <summary>
        ///// 规则：上级召唤需要2只解放的最低级别 7
        ///// </summary>
        //static public int superiorSummonTwo = 7;
        ///// <summary>
        ///// 规则：上级召唤需要3只解放的最低级别 9
        ///// </summary>
        //static public int superiorSummonThree = 9;
        ///// <summary>
        ///// 规则：玩家失败LP值（低于或等于 0
        ///// </summary>
        //static public int plyaerFailureLP = 0;
        ///// <summary>
        ///// 规则：玩家失败抽卡时卡组卡牌数 0
        ///// </summary>
        //static public int plyaerFailureDeckNum = 0;
        ///// <summary>
        ///// 规则：回合内怪兽卡可攻击次数 1
        ///// </summary>
        //static public int monsterAttackNum = 1;
        ///// <summary>
        ///// 规则：一方场地上怪兽卡上限 5
        ///// </summary>
        //static public int MontserFiledNumMax = 5;
        ///// <summary>
        ///// 规则：一方场地上魔法or陷阱卡上限 5
        ///// </summary>
        //static public int SpellorTrapFiledNumMax = 5;
        
        /// <summary>
        /// 当前Game对象
        /// </summary>
        static public Game g = null;
        
        /// <summary>
        /// 判断是否时回合操作效果
        /// </summary>
        /// <param name="e">目标效果</param>
        static public bool JudgeIsRoundActionEffect(Effect e)
        {
            if (e.effectParameter[0] == "NextStage" | e.effectParameter[0] == "NextRound")
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// 判断操作效果是否能执行
        /// </summary>
        /// <param name="e">目标效果对象</param>
        static public bool JudgeActionEffectEnableLaunch(Effect e)
        {
            if (e.enableLuanch == false)//效果不能发动
            {
                return false;
            }
            if (!(e.gameStage.Contains(Rule.g.stage)))
            {
                return false;
            }
            if (!(e.gameStage.Contains(Rule.g.stage)))
            {
                return false;
            }
            switch (e.effectParameter[0])//操作方法名
            {
                case "NormalSummon"://通常召唤
                    if (e.card.FindOwnPlayer(g).numNormalSummon == 0)//卡牌控制者的回合通常召唤次数为0
                    {
                        return false;
                    }
                    if (e.card.field != FieldEnum.Hand)//卡牌不在手牌上
                    {
                        return false;
                    }
                    if (Rule.g.GetNumOfMonsterField(e.card.currentController) == 5)//怪兽区已满
                    {
                        return false;
                    }
                    break;
                case "SuperiorSummon"://上级召唤
                    if (e.card.FindOwnPlayer(Rule.g).numNormalSummon == 0)//卡牌控制者的回合通常召唤次数为0
                    {
                        return false;
                    }
                    if (e.card.field != FieldEnum.Hand)//卡牌不在手牌上
                    {
                        return false;
                    }
                    if (Rule.g.GetNumOfMonsterField(e.card.currentController) < int.Parse(e.effectParameter[2]))//场上解放数量不够
                    {
                        return false;
                    }
                    if (Rule.g.GetNumOfMonsterField(e.card.currentController) == 5)//怪兽区已满
                    {
                        return false;
                    }
                    break;
                case "FlipSummon"://反转召唤
                    if (e.card.FindOwnPlayer(Rule.g).numNormalSummon == 0)//卡牌控制者的回合通常召唤次数为0
                    {
                        return false;
                    }
                    if (e.card.field != FieldEnum.Monster)//卡牌不在场上
                    {
                        return false;
                    }
                    if (e.card.state != StateEnum.BackDefence)//不处于里侧守备状态
                    {
                        return false;
                    }
                    break;
                case "SetSummon"://前场放置
                    if (e.card.FindOwnPlayer(Rule.g).numNormalSummon == 0)//卡牌控制者的回合通常召唤次数为0
                    {
                        return false;
                    }
                    if (e.card.field != FieldEnum.Hand)//卡牌不在场上
                    {
                        return false;
                    }
                    if (Rule.g.GetNumOfMonsterField(e.card.currentController) == 5)//怪兽区已满
                    {
                        return false;
                    }
                    break;
                case "BackSet"://后场放置
                    if (e.card.field != FieldEnum.Hand)//不在手牌
                    {
                        return false;
                    }
                    if (Rule.g.GetNumOfSpellorTrapField(e.card.currentController) == 5)//魔法陷阱区已满
                    {
                        return false;
                    }
                    break;
                case "ChangeFrom"://改变表侧形式
                    if (e.card.field != FieldEnum.Monster)//卡牌不在场上
                    {
                        return false;
                    }
                    break;
                default:
                    //等待
                    break;
            }

            return true;
        }
        /// <summary>
        /// 判断主动效果是否能执行
        /// </summary>
        /// <param name="e">目标效果对象</param>
        static public bool JudgeActiveEffectEnableLaunch(Effect e)
        {
            if (e.card.controller == g.currentPlayer)//当前回合玩家控制的卡牌
            {
                if (e.enableLuanch == false)//效果能否发动
                {
                    return false;
                }
                if (e.isAction == false)//卡牌主动效果
                {
                    if (!(e.gameStage.Contains(g.stage)))//当前是否是可发动回合阶段
                    {
                        return false;
                    }
                    if (!(e.gameBattle.Contains(g.battle)))//当前是否是可发动战斗阶段
                    {
                        return false;
                    }
                    if (e.copyNum == 0)//回合发动次数为0时
                    {
                        return false;
                    }
                    if (g.isChain == false)//游戏没处于连锁
                    {
                        if (e.afterAction != "")//有前置操作条件
                        {
                            return false;
                        }
                    }
                    else//游戏处在连锁中
                    {
                        if (e.speed == 1)//效果速度为1
                        {
                            return false;
                        }
                        if (e.speed <= g.chains.Last().speed)//效果速度小于连锁中最后个效果的速度
                        {
                            return false;
                        }
                        if (e.afterAction != "")//有前置操作条件
                        {
                            if (e.afterAction != g.gameAction)//前置操作不符合
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            else//非当前回合玩家控制的卡牌
            {
                if (e.enableLuanch == false)//效果能否发动
                {
                    return false;
                }
                if (g.isChain == true)//游戏处在连锁中
                {
                    if (e.speed <= g.chains.Last().speed)// 效果速度小于连锁中最后个效果的速度
                    {
                        return false;
                    }
                    if (e.afterAction != "")//有前置操作条件
                    {
                        if (e.afterAction != g.gameAction)//前置操作不符合
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// 判断被动效果是否能执行
        /// </summary>
        /// <param name="e">目标效果对象</param>
        static public bool JudgePassiveEffectEnableLuanch(Effect e)
        {
            if (e.enableLuanch == false)
            {
                return false;
            }
            if (e.copyNum == 0)
            {
                return false;
            }
            if (!(e.gameStage.Contains(g.stage)))
            {
                return false;
            }
            if (!(e.gameBattle.Contains(g.stage)))
            {
                return false;
            }
            //或许还有

            return true;
        }



        /// <summary>
        /// 判断是否是目标卡牌
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        static public bool JudgeIsTargetCard(DuelCard card, object[][] targetConditions)
        {
            foreach (object[] os in targetConditions)
            {
                bool flag = false;//标记 默认false
                int i = 1;//下标，默认 1
                switch ((string)os[0])
                {
                    case "copyName":
                        foreach (string str in os)
                        {
                            if (card.copyName.Contains(str))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {
                            return false;
                        }
                        break;
                    case "copyRuleName":
                        foreach (string str in os)
                        {
                            if (card.copyName.Contains(str))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {
                            return false;
                        }
                        break;
                    case "copyLevel":
 
                        while (os[i]!=null)
                        {
                            if (card.copyLevel == (int)os[i])
                            {
                                flag = true;
                                break;
                            }
                            i++;
                        }
                        if (flag == false)
                        {
                            return false;
                        }
                        break;
                    case "copyAttribute":
                        while (os[i] != null)
                        {
                            if (card.copyAttribute == (int)os[i])
                            {
                                flag = true;
                                break;
                            }
                            i++;
                        }
                        if (flag == false)
                        {
                            return false;
                        }
                        break;
                    case "copyType":
                        while (os[i] != null)
                        {
                            if (card.copyType== (int)os[i])
                            {
                                flag = true;
                                break;
                            }
                            i++;
                        }
                        if (flag == false)
                        {
                            return false;
                        }
                        break;
                    case "copyRace":
                        while (os[i] != null)
                        {
                            if (card.copyRace == (int)os[i])
                            {
                                flag = true;
                                break;
                            }
                            i++;
                        }
                        if (flag == false)
                        {
                            return false;
                        }
                        break;
                    case "copyAtk":
                        switch ((int)os[1])
                        {
                            case -1://小于
                                if (card.copyAtk > (int)os[2]) 
                                {
                                    return false;
                                }
                                break;
                            case 0://之间
                                if (card.copyAtk < (int)os[2])
                                {
                                    return false;
                                }
                                if (card.copyAtk > (int)os[3])
                                {
                                    return false;
                                }
                                break;
                            case 1://大于
                                if (card.copyAtk < (int)os[2]) 
                                {
                                    return false;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case "copyDef":
                        switch ((int)os[1])
                        {
                            case -1://小于
                                if (card.copyDef > (int)os[2])
                                {
                                    return false;
                                }
                                break;
                            case 0://之间
                                if (card.copyDef < (int)os[2])
                                {
                                    return false;
                                }
                                if (card.copyDef > (int)os[3])
                                {
                                    return false;
                                }
                                break;
                            case 1://大于
                                if (card.copyDef < (int)os[2])
                                {
                                    return false;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case "currentController":
                        if (!(card.currentController == (ControllerEnum)os[1]))
                        {
                            return false;
                        }
                        break;
                    case "field":
                        while (os[i] != null)
                        {
                            if (card.field == (FieldEnum)os[i])
                            {
                                flag = true;
                                break;
                            }
                            i++;
                        }
                        if (flag == false)
                        {
                            return false;
                        }
                        break;
                    case "state":
                        while (os[i] != null)
                        {
                            if (card.state == (StateEnum)os[i])
                            {
                                flag = true;
                                break;
                            }
                            i++;
                        }
                        if (flag == false)
                        {
                            return false;
                        }
                        break;
                    default:
                        //待定
                        break;
                }
            
            }

            return true;
        }
        /// <summary>
        /// 判断效果类型,返回值为 null  则出错
        /// </summary>
        /// <param name="e">目标效果</param>
        static public string JudgeEffectType(Effect e)
        {
            string eType = null;
            if (e.isAction == true)//操作方法
            {
                eType = e.effectParameter[0];
            }
            else
            {
                if (e.effectParameter[0] == "NextStage" || e.effectParameter[0] == "NextRound")
                {
                    eType = e.effectParameter[0];
                }
                eType = "effect";
            }

            return eType;
        }
        

        

        /// <summary>
        /// 创建目标卡牌的通常召唤操作
        /// </summary>
        /// <param name="card">目标卡牌</param>
        /// <returns></returns>
        static public Effect CreatNormalSummonAction(DuelCard card)
        {
            Effect e = new Effect(card);
            e.name = "通常召唤";
            e.isAction = true;
            e.isActive = true;
            e.isInChain = true;
            e.gameStage = new int[] { 3, 5 };
            e.gameBattle = new int[] { 0 };
            e.targetNum = 1;
            e.targetCondition = new object[][] {
                new object[]{ "copyType", 11, 21, 200021},
                new object[]{ "copyLevel", 1, 2, 3, 4},
                new object[]{ "field", FieldEnum.Hand}};
            e.effectParameter = new string[] { "NormalSummon", card.no.ToString(), true.ToString()};

            return e;
        }
        /// <summary>
        /// 创建目标卡牌的上级召唤操作
        /// </summary>
        /// <param name="card">目标卡牌</param>
        /// <returns></returns>
        static public Effect CreatSuperiorSummonAction(DuelCard card)
        {
            Effect e = new Effect(card);
            e.name = "上级召唤";
            e.isAction = true;
            e.isActive = true;
            e.isInChain = true;
            e.gameStage = new int[] { 3, 5 };
            e.gameBattle = new int[] { 0 };
            e.targetNum = 1;
            e.targetCondition = new object[][] {
                new object[]{ "copyType", 11, 21, 200021},
                new object[]{ "copyLevel", 5, 6, 7, 8, 9, 10, 11, 12},
                new object[]{ "field", FieldEnum.Hand}};
            if (card.copyLevel < 7)
                e.effectParameter = new string[] { "SuperiorSummon", card.no.ToString(), "1", true.ToString() };
            else if (card.copyLevel < 9)
                e.effectParameter = new string[] { "SuperiorSummon", card.no.ToString(), "2", true.ToString() };
            else
                e.effectParameter = new string[] { "SuperiorSummon", card.no.ToString(), "3", true.ToString() };

            return e;
        }
        /// <summary>
        /// 创建目标卡牌的反转召唤操作
        /// </summary>
        /// <param name="card">目标卡牌</param>
        /// <returns></returns>
        static public Effect CreatFlipSummonAction(DuelCard card)
        {
            Effect e = new Effect(card);
            e.name = "反转召唤";
            e.isAction = true;
            e.isActive = true;
            e.isInChain = true;
            e.gameStage = new int[] { 3, 5 };
            e.gameBattle = new int[] { 0 };
            e.targetNum = 1;
            e.targetCondition = new object[][] {
                new object[]{ "copyType", 200021},
                new object[]{ "copyLevel", 1, 2, 3, 4},
                new object[]{ "field", FieldEnum.Monster},
                new object[]{ "state",  StateEnum.BackDefence} };
            e.effectParameter = new string[] { "FlipSummon", card.no.ToString(), true.ToString() };

            return e;
        }
        /// <summary>
        /// 创建目标卡牌前场放置操作
        /// </summary>
        /// <param name="card">目标卡牌</param>
        /// <returns></returns>
        static public Effect CreatSetSummonAction(DuelCard card)
        {
            Effect e = new Effect(card);
            e.name = "前场放置";
            e.isAction = true;
            e.isActive = true;
            e.isInChain = true;
            e.gameStage = new int[] { 3, 5 };
            e.gameBattle = new int[] { 0 };
            e.targetNum = 1;
            e.targetCondition = new object[][] {
                new object[]{ "copyType", 11, 21, 200021},
                new object[]{ "copyLevel", 1, 2, 3, 4},
                new object[]{ "field", FieldEnum.Hand} };
            e.effectParameter = new string[] { "SetSummon", card.no.ToString(), true.ToString() };

            return e;
        }
        /// <summary>
        /// 创建目标卡牌后场放置操作
        /// </summary>
        /// <param name="card">目标卡牌</param>
        /// <returns></returns>
        static public Effect CreatSetAction(DuelCard card)
        {
            Effect e = new Effect(card);
            e.name = "后场放置";
            e.isAction = true;
            e.isActive = true;
            e.isInChain = true;
            e.gameStage = new int[] { 3, 5 };
            e.gameBattle = new int[] { 0 };
            e.targetNum = 1;
            e.targetCondition = new object[][] {
                new object[]{ "copyType", 2, 10002, 20002, 40002, 80002, 82, 4, 20004, 10004},
                new object[]{ "field", FieldEnum.Hand}};
            e.effectParameter = new string[] { "BackSet", card.no.ToString(), true.ToString() };

            return e;
        }
        /// <summary>
        /// 创建目标卡牌攻击操作
        /// </summary>
        /// <param name="card">目标卡牌</param>
        /// <returns></returns>
        static public Effect CreatAttackAction(DuelCard card)
        {
            //未完成
            Effect e = new Effect(card);
            e.name = "攻击";
            e.num = 1;
            e.copyNum = 1;
            e.isAction = true;
            e.isActive = true;
            e.isInChain = true;
            e.gameStage = new int[] { 4 };
            e.gameBattle = new int[] { 1 };
            e.targetNum = 1;
            e.targetCondition = new object[][] {
                new object[]{ "copyType", 11, 21, 41, 81, 61, 200021, 2000021},
                new object[]{ "field", FieldEnum.MainDeck}};
            e.effectParameter = new string[] { "DeclaringAttack", card.no.ToString(), true.ToString() };

            return e;
        }
        /// <summary>
        /// 创建目标卡牌改变表侧形式操作
        /// </summary>
        /// <param name="card">目标卡牌</param>
        /// <returns></returns>
        static public Effect CreatChangeFromAction(DuelCard card)
        {
            Effect e = new Effect(card);
            e.name = "改变表侧形式";
            e.num = 1;
            e.copyNum = 1;
            e.isAction = true;
            e.isActive = true;
            e.isInChain = true;
            e.gameStage = new int[] { 3, 5 };
            e.gameBattle = new int[] { 0 };
            e.targetNum = 1;
            e.targetCondition = new object[][] {
                new object[]{ "copyType", 11, 21, 41, 81, 61, 200021, 2000021},
                new object[]{ "field", FieldEnum.MainDeck}};
            e.effectParameter = new string[] { "ChangeFrom", card.no.ToString(), true.ToString() };

            return e;
        }


        /// <summary>
        /// 创建下到一个回合阶段操作
        /// </summary>
        static public Effect CreatNextStageAction()
        {
            Effect e = new Effect();
            e.card = null;
            e.enableLuanch = true;
            e.name = "下个阶段";
            e.effectParameter = new string[] { "NextStage", true.ToString() };

            return e;
        }
        /// <summary>
        /// 创建到下一个回合操作
        /// </summary>
        static public Effect CreatNextRound()
        {
            Effect e = new Effect();
            e.card = null;
            e.enableLuanch = true;
            e.name = "下个回合";
            e.effectParameter = new string[] { "NextRound", true.ToString() };

            return e;
        }

        /// <summary>
        /// 发动
        /// </summary>
        /// <param name="e">效果对象</param>
        static public void Luanch(Effect e)
        {
            string[] content = null;
            switch (JudgeEffectType(e))
            {
                case "NormalSummon"://通常召唤
                     //待完成                    
                    MessageControl.Send(e.card.currentController, "通常召唤", content, MessageEnum.ActionMessage);
                    break;
                case "SuperiorSummon"://上级召唤
                    //待完成
                    MessageControl.Send(e.card.currentController, "上级召唤", content, MessageEnum.ActionMessage);
                    break;
                case "FlipSummon"://反转召唤
                    //待完成
                    MessageControl.Send(e.card.currentController, "反转召唤", content, MessageEnum.ActionMessage);
                    break;
                case "SetSummon"://前场放置
                    //待完成
                    MessageControl.Send(e.card.currentController, "前场放置", content, MessageEnum.ActionMessage);
                    break;
                case "BackSet"://后场放置
                    //待完成
                    MessageControl.Send(e.card.currentController, "后场放置", content, MessageEnum.ActionMessage);
                    break;
                case "DeclaringAttack"://攻击
                    //待写
                    MessageControl.Send(e.card.currentController, "攻击宣言", content, MessageEnum.ActionMessage);
                    break;
                case "ChangeFrom"://改变表侧形式
                    //待完成
                    MessageControl.Send(e.card.currentController, "改变表侧形式", content, MessageEnum.ActionMessage);
                    break;
                case "NextStage"://下个回合阶段
                    //待完成
                    MessageControl.Send(g.currentPlayer, "进入回合阶段", content, MessageEnum.RoundMessage);
                    break;
                case "NextRound"://下个回合
                    //待完成
                    MessageControl.Send(g.currentPlayer, "进入回合", content, MessageEnum.RoundMessage);
                    break;
                case "effect"://效果
                    //待完成


                    break;
                case null://出错
                    break;
                default:
                    //待写
                    break;
            }
        }
        /// <summary>
        /// 发动
        /// </summary>
        /// <param name="m">消息对象</param>
        static public void Luanch(Message m)
        {
            switch (m.messageClass)
            {
                case MessageEnum.SystemMessage://系统消息
                    break;
                case MessageEnum.EffectMessage://效果消息
                    break;
                case MessageEnum.ActionMessage://操作消息
                    switch (m.content[0])
                    {
                        case "NormalSummon"://通常召唤
                            EffectRealization.NormalSummon(int.Parse(m.content[1]), int.Parse(m.content[2]), bool.Parse(m.content[3]));
                            break;
                        case "SuperiorSummon"://上级召唤
                            switch (m.content.Length)
                            {
                                case 5:
                                    EffectRealization.SuperiorSummon(int.Parse(m.content[1]), int.Parse(m.content[2]), 
                                        new int[] { int.Parse(m.content[3]) }, bool.Parse(m.content[4]));
                                    break;
                                case 6:
                                    EffectRealization.SuperiorSummon(int.Parse(m.content[1]), int.Parse(m.content[2]),
                                        new int[] { int.Parse(m.content[3]), int.Parse(m.content[4]) }, bool.Parse(m.content[5]));
                                    break;
                                case 7:
                                    EffectRealization.SuperiorSummon(int.Parse(m.content[1]), int.Parse(m.content[2]),
                                        new int[] { int.Parse(m.content[3]), int.Parse(m.content[4]), int.Parse(m.content[5]) }, bool.Parse(m.content[6]));
                                    break;
                            }
                            break;
                        case "FlipSummon"://反转召唤
                            break;
                        case "SetSummon"://前场放置
                            break;
                        case "BackSet"://后场放置
                            break;
                        case "DeclaringAttack"://攻击
                            //待写
                            break;
                        case "ChangeFrom"://改变表侧形式
                            break;
                    }
                    break;
                case MessageEnum.RoundMessage://回合消息
                    break;
                default:
                    break;
            }
            string method = m.content[0];

        }


        /// <summary>
        /// 获取玩家名称，通过玩家身份
        /// </summary>
        /// <param name="controllerEnum">玩家身份</param>
        static public string GetPlayerName(ControllerEnum controllerEnum)
        {
            foreach (Player p in g.players)
            {
                if (p.GetStatus == controllerEnum)
                {
                    return p.GetName;
                }
            }

            return null;
        }
        /// <summary>
        /// 获取卡牌，通过卡牌编号
        /// </summary>
        /// <param name="no">卡牌编号</param>
        static public DuelCard GetDuelCard(int no)
        {
            foreach (List<DuelCard> lc in g.decks)
            {
                foreach (DuelCard c in lc)
                {
                    if (c.no == no)
                    {
                        return c;
                    }
                }
            }

            return null;
        }
    }
}
