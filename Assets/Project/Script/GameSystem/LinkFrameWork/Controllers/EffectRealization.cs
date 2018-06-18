using HYJ.Models;

namespace HYJ.Controllers
{
    /// <summary>
    /// 效果方法实现静态类
    /// </summary>
    public class EffectRealization
    {
        ///// <summary>
        ///// 通常召唤
        ///// </summary>
        ///// <param name="card">目标卡牌</param>
        //static public void NormalSummon(DuelCard card)
        //{
        //    card.field = FieldEnum.Monster;
        //    card.state = StateEnum.SideAttack;
        //}
        ///// <summary>
        ///// 上级召唤
        ///// </summary>
        ///// <param name="card">目标卡牌</param>
        //static public void SuperiorSummon(DuelCard card)
        //{
        //    card.field = FieldEnum.Monster;
        //    card.state = StateEnum.SideAttack;
        //}
        ///// <summary>
        ///// 反转召唤
        ///// </summary>
        ///// <param name="card">目标卡牌</param>
        //static public void FlipSummon(DuelCard card)
        //{
        //    card.state = StateEnum.SideDefence;
        //}
        ///// <summary>
        ///// 前场放置
        ///// </summary>
        ///// <param name="card">目标卡牌</param>
        //static public void SetSummon(DuelCard card)
        //{
        //    card.field = FieldEnum.Monster;
        //    card.state = StateEnum.BackDefence;
        //}
        ///// <summary>
        ///// 后场放置
        ///// </summary>
        ///// <param name="card">目标卡牌</param>
        //static public void BackSet(DuelCard card)
        //{
        //    card.field = FieldEnum.SpellorTrap;
        //    card.state = StateEnum.BackSet;
        //}
        ///// <summary>
        ///// 改变表侧形式
        ///// </summary>
        ///// <param name="card">目标卡牌</param>
        //static public void ChangeFrom(DuelCard card)
        //{
        //    if (card.state == StateEnum.SideAttack)
        //    {
        //        card.state = StateEnum.SideDefence;
        //    }
        //    else if (card.state == StateEnum.SideDefence)
        //    {
        //        card.state = StateEnum.SideAttack;
        //    }
        //    else if (card.state == StateEnum.BackDefence)
        //    {
        //        //
        //    }

        //}
        ///// <summary>
        ///// 攻击
        ///// </summary>
        ///// <param name="attacker">攻击发起者</param>
        ///// <param name="target">攻击目标</param>
        //static public void Attack(DuelCard attacker, DuelCard target)
        //{
        //    //
        //}
        //static public void DrawCard()
        //{
        //    //
        //}
        //static public void AbandanCard()
        //{
        //    //
        //}



        ///// <summary>
        ///// 召唤卡牌操作
        ///// </summary>
        ///// <param name="target">目标卡牌</param>
        ///// <param name="effective">操作有效性</param>
        //static public void Summon(DuelCard target, bool effective = true)
        //{
        //    target.field = FieldEnum.MainDeck;
        //    ///
        //}
        ///// <summary>
        ///// 破坏卡牌操作
        ///// </summary>
        ///// <param name="target">目标卡牌集合</param>
        ///// <param name="effective">操作有效性</param>
        //static public void Destroy(List<DuelCard> target, bool effective = true)
        //{
        //    foreach (DuelCard c in target)
        //    {
        //        c.field = FieldEnum.Cemetery;
        //        ///
        //    }
        //}
        ///// <summary>
        ///// 除外卡牌操作
        ///// </summary>
        ///// <param name="target">目标卡牌集合</param>
        ///// <param name="effective">操作有效性</param>
        //static public void Except(List<DuelCard> target, bool effective = true)
        //{
        //    foreach (DuelCard c in target)
        //    {
        //        c.field = FieldEnum.Exception;
        //        ////
        //    }
        //}
        ///// <summary>
        ///// 加入手牌操作
        ///// </summary>
        ///// <param name="target">目标卡牌集合</param>
        ///// <param name="effective">操作有效性</param>
        //static public void JoinHand(List<DuelCard> target, bool effective = true)
        //{
        //    foreach (DuelCard c in target)
        //    {
        //        c.field = FieldEnum.Hand;
        //    }
        //}
        ///// <summary>
        ///// 改变卡牌ATK
        ///// </summary>
        ///// <param name="target">目标卡牌</param>
        ///// <param name="IsAdd">是否增加 true增加， false 减少</param>
        ///// <param name="num">变化值</param>
        ///// <param name="effective">操作有效性</param>
        //static public void ChangeATK(List<DuelCard> target, bool IsAdd, int num, bool effective = true)
        //{ }
        ///// <summary>
        ///// 改变卡牌DEF
        ///// </summary>
        ///// <param name="target">目标卡牌</param>
        ///// <param name="IsAdd">是否增加 true增加， false 减少</param>
        ///// <param name="num">变化值</param>
        ///// <param name="effective">操作有效性</param>
        //static public void ChangeDEF(List<DuelCard> target, bool IsAdd, int num, bool effective = true)
        //{ }

        /// <summary>
        /// Game对象
        /// </summary>
        static public Game g = null;

        /// <summary>
        /// 通常召唤
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="tno"></param>
        /// <param name="effective"></param>
        static public void NormalSummon(int cno, int tno, bool effective)
        {
            if (effective == true)
            {
                Rule.GetDuelCard(cno).field = FieldEnum.Monster;
                g.handField[int.Parse(g.currentPlayer.ToString())].Remove(Rule.GetDuelCard( cno));//手牌去除此卡
                g.cemeteryField[int.Parse(g.currentPlayer.ToString())].Add(Rule.GetDuelCard( cno));//怪兽区域增加此卡
            }
        }

        /// <summary>
        /// 上级召唤
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="tno"></param>
        /// <param name="lno"></param>
        /// <param name="effective"></param>
        static public void SuperiorSummon(int cno, int tno, int[] lno, bool effective)
        {
            if (effective == true)
            {
                foreach (int i in lno)
                {
                    Liberate(i, true);
                }
                Rule.GetDuelCard(cno).field = FieldEnum.Monster;
                g.handField[int.Parse(g.currentPlayer.ToString())].Remove(Rule.GetDuelCard( cno));//手牌去除此卡
                g.cemeteryField[int.Parse(g.currentPlayer.ToString())].Add(Rule.GetDuelCard( cno));//怪兽区域增加此卡
            }
        }
        /// <summary>
        /// 反转召唤
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="effective"></param>
        static public void FlipSummon(int cno, bool effective)
        {

        }
        /// <summary>
        /// 前场放置
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="tno"></param>
        /// <param name="effective"></param>
        static public void SetSummon(int cno, int tno, bool effective)
        {

        }
        /// <summary>
        /// 后场放置
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="tno"></param>
        /// <param name="effective"></param>
        static public void BackSet(int cno, int tno, bool effective)
        {

        }
        /// <summary>
        /// 改变表侧形式
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="effective"></param>
        static public void ChangeFrom(int cno, bool effective)
        {

        }
        /// <summary>
        /// 攻击宣言
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="tno"></param>
        /// <param name="effective"></param>
        static public bool DeclaringAttack(int cno, int tno, bool effective)
        {
            if (effective == false)
            {
                return false;
            }
            if (Rule.GetDuelCard(cno).field != FieldEnum.Monster)
            {
                return false;
            }
            if (Rule.GetDuelCard(tno).field != FieldEnum.Monster)
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// 伤害计算
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="tno"></param>
        /// <param name="effective"></param>
        static public int CalculationHurt(int cno, int tno, bool effective)
        {
            int num = 0;
            if (effective == true)
            {
                if (Rule.GetDuelCard(tno).state == StateEnum.BackDefence || Rule.GetDuelCard(tno).state == StateEnum.SideDefence)
                {
                    if (Rule.GetDuelCard(cno).copyAtk > Rule.GetDuelCard(tno).copyDef)
                    {
                        num = 0;
                        BattleHurt(Rule.GetDuelCard(tno).currentController, num, true);
                        //Destroy(tno, true);
                        return 1;
                    }
                    else if (Rule.GetDuelCard(cno).copyAtk < Rule.GetDuelCard(tno).copyDef)
                    {
                        num = Rule.GetDuelCard(tno).copyDef - Rule.GetDuelCard(cno).copyAtk;
                        BattleHurt(Rule.GetDuelCard(cno).currentController,  num, true);
                        //Destroy(cno, true);
                        return 2;
                    }
                    else
                    {
                        //为空
                        return 0;
                    }
                }
                else
                {
                    if (Rule.GetDuelCard(cno).copyAtk > Rule.GetDuelCard(tno).copyAtk)
                    {
                        num = Rule.GetDuelCard(cno).copyAtk - Rule.GetDuelCard(tno).copyAtk;
                        BattleHurt(Rule.GetDuelCard(tno).currentController, num, true);
                        Destroy(tno, true);
                        return 1;
                    }
                    else if (Rule.GetDuelCard(cno).copyAtk < Rule.GetDuelCard(tno).copyAtk)
                    {
                        num = Rule.GetDuelCard(tno).copyAtk - Rule.GetDuelCard(cno).copyAtk;
                        BattleHurt(Rule.GetDuelCard(cno).currentController, num, true);
                        //Destroy(cno, true);
                        return 2;
                    }
                    else
                    {
                        //Destroy(cno, true);
                        //Destroy(tno, true);
                        return 3;
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// 战斗结束
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="tno"></param>
        /// <param name="no"></param>
        /// <param name="effective"></param>
        static public void BattleEnd(int cno, int tno, int no, bool effective)
        {
            if (effective == true)
            {
                switch (no)
                {
                    case 0:
                        //无
                        break;
                    case 1:
                        Destroy(tno, true);
                        break;
                    case 2:
                        Destroy(cno, true);
                        break;
                    case 3:
                        Destroy(cno, true);
                        Destroy(tno, true);
                        break;
                    default:
                        //待写
                        break;
                }
            }
        }
        /// <summary>
        /// 下个回合阶段
        /// </summary>
        /// <param name="effective"></param>
        static public void NextStage(bool effective)
        {
            if (effective == true)
            {
                if (g.stage == 6)
                {
                    g.stage = 0;
                }
                g.stage++;
            }
        }
        /// <summary>
        /// 下个回合
        /// </summary>
        /// <param name="effective"></param>
        static public void NextRound(bool effective)
        {
            if (effective == true)
            {
                g.round++;
            }
        }
        /// <summary>
        /// 解放
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="effective"></param>
        static public void Liberate(int cno, bool effective)
        {
            Rule.GetDuelCard( cno).field = FieldEnum.Cemetery;
            g.monsterField[int.Parse(g.currentPlayer.ToString())].Remove(Rule.GetDuelCard( cno));//手牌去除此卡
            g.cemeteryField[int.Parse(g.currentPlayer.ToString())].Add(Rule.GetDuelCard( cno));//怪兽区域增加此卡
        }
        /// <summary>
        /// 破坏卡牌
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="effective"></param>
        static public void Destroy(int cno, bool effective)
        {

        }
        /// <summary>
        /// 除外卡牌
        /// </summary>
        /// <param name="cno"></param>
        /// <param name="effective"></param>
        static public void Except(int cno, bool effective)
        {

        }
        /// <summary>
        /// 加入手牌
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cno"></param>
        /// <param name="effective"></param>
        static public void JoinHand(ControllerEnum player, int cno, bool effective)
        {

        }
        /// <summary>
        /// 回合抽卡
        /// </summary>
        /// <param name="player"></param>
        /// <param name="effective"></param>
        static public void RoundDrawCard(ControllerEnum player, bool effective)
        {

        }
        /// <summary>
        /// 效果伤害
        /// </summary>
        /// <param name="player"></param>
        /// <param name="num"></param>
        /// <param name="effective"></param>
        static public void EffectHurt(ControllerEnum player, int num, bool effective)
        {

        }
        /// <summary>
        /// 战斗伤害
        /// </summary>
        /// <param name="player"></param>
        /// <param name="num"></param>
        /// <param name="effective"></param>
        static public void BattleHurt(ControllerEnum player, int num, bool effective)
        {

        }


    }
}
