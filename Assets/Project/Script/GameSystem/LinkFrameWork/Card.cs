using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

/// <summary>
/// 作者：HYJ
/// 创建时间：5.12
/// 创建内容：Card类及其扩展类
/// 最后修改：5.16
/// 修改内容：1.Card类构造函数重载
///                  2.Card类重载 “ = = ”符号，“！=”符号
///                  3.DuelCard类部分属性字段的完成，枚举类型Field
/// 待办事项：DuelCard类补全
/// </summary>
namespace HYJ
{
   
    /// <summary>
    /// Card基类
    /// </summary>
    public class Card
    {
        /// <summary>
        /// 卡牌ID，唯一值。 否决值 -1
        /// </summary>
        protected int id = -1;
        /// <summary>
        /// 卡牌名称。否决值 ""
        /// </summary>
        protected string name = "";
        /// <summary>
        /// 卡牌规则名称，一般情况下等于卡牌名称。否决值 ""
        /// </summary>
        protected string ruleName = "";
        /// <summary>
        /// 卡牌星级。否决值 -1
        /// </summary>
        protected int level = -1;
        /// <summary>
        /// 卡牌属性。否决值 -1
        /// </summary>
        protected int attribute = -1;
        /// <summary>
        /// 卡牌种类。否决值 -1
        /// </summary>
        protected int type = -1;
        /// <summary>
        /// 卡牌攻击力。否决值 -1
        /// </summary>
        protected int atk = -1;
        /// <summary>
        /// 卡牌守备力。否决值 -1
        /// </summary>
        protected int def = -1;
        /// <summary>
        /// 卡牌效果文本。否决值 ""
        /// </summary>
        protected string effectText = "";
        
        /// <summary>
        /// 卡牌转译后属性。否决值 ""
        /// </summary>
        protected string translatedAttribute = "";
        /// <summary>
        /// 卡牌转译后种类。否决值 ""
        /// </summary>
        protected string translatedType = "";

        public Card() { }

        /// <summary>
        /// Card类构造函数
        /// </summary>
        /// <param name="cId">卡牌id</param>
        /// <param name="cName">卡牌名称</param>
        /// <param name="cLevel">卡牌星级</param>
        /// <param name="cAttribute">卡牌属性</param>
        /// <param name="cType">卡牌种类</param>
        /// <param name="cAtk">卡牌攻击力</param>
        /// <param name="cDef">卡牌守备力</param>
        /// <param name="cEffectText">卡牌效果文本</param>
        public Card(int cId, string cName, int cLevel, int cAttribute, int cType, int cAtk, int cDef, string cEffectText)
        {
            this.id = cId;
            this.name = cName;
            this.ruleName = cName;
            this.level = cLevel;
            this.attribute = cAttribute;
            this.type = cType;
            this.atk = cAtk;
            this.def = cDef;
            this.effectText = cEffectText;
        }
        /// <summary>
        /// Card类构造函数
        /// </summary>
        /// <param name="cId">卡牌id</param>
        /// <param name="cName">卡牌名称</param>
        /// <param name="cRuleName">卡牌规则名称</param>
        /// <param name="cLevel">卡牌星级</param>
        /// <param name="cAttribute">卡牌属性</param>
        /// <param name="cType">卡牌种类</param>
        /// <param name="cAtk">卡牌攻击力</param>
        /// <param name="cDef">卡牌守备力</param>
        /// <param name="cEffectText">卡牌效果文本</param>
        public Card(int cId, string cName, string cRuleName, int cLevel, int cAttribute, int cType, int cAtk, int cDef, string cEffectText)
        {
            this.id = cId;
            this.name = cName;
            this.ruleName = cRuleName;
            this.level = cLevel;
            this.attribute = cAttribute;
            this.type = cType;
            this.atk = cAtk;
            this.def = cDef;
            this.effectText = cEffectText;
        }

        /// <summary>
        /// 转译属性为字符串
        /// </summary>
        /// <param name="cAttribute">卡牌属性代码</param>
        /// <returns>卡牌属性字符串</returns>
        public string TranslaleAttribute(int cAttribute)
        {
            ///待补充

            return "";
        }
        /// <summary>
        /// 转译种类为字符串
        /// </summary>
        /// <param name="cType">卡牌种类代码</param>
        /// <returns>卡牌种类字符串</returns>
        public string TranslateType(int cType)
        {
            ///待完成

            return "";
        }
        /// <summary>
        /// 重载Card类 “==”符号，实例2的属性字段为否决值的不进行判断。
        /// </summary>
        /// <param name="c1">Card类实例1</param>
        /// <param name="c2">Card类实例2</param>
        /// <returns>“==”比较结果的bool值</returns>
        public static bool operator ==(Card c1, Card c2)
        {
            bool flag = true;
            //判断卡牌ID
            if (!c2.id.Equals(-1))
            {
                flag = c1.id.Equals(c2.id);
            }
            if (flag.Equals(false))
            {
                return false;
            }
            //判断卡牌名称
            if (!c2.name.Equals(""))
            {
                flag = c1.name.Equals(c2.name);
            }
            if (flag.Equals(false))
            {
                return false;
            }
            //判断卡牌规则名称
            if (!c2.ruleName.Equals(""))
            {
                flag = c1.ruleName.Equals(c2.ruleName);
            }
            if (flag.Equals(false))
            {
                return false;
            }
            //判断卡牌星级
            if (!c2.level.Equals(-1))
            {
                flag = c1.level.Equals(c2.level);
            }
            if (flag.Equals(false))
            {
                return false;
            }
            //判断卡牌属性
            if (!c2.attribute.Equals(-1))
            {
                flag = c1.attribute.Equals(c2.attribute);
            }
            if (flag.Equals(false))
            {
                return false;
            }
            //判断卡牌种类
            if (!c2.type.Equals(-1))
            {
                flag = c1.type.Equals(c2.type);
            }
            if (flag.Equals(false))
            {
                return false;
            }
            //判断卡牌攻击力
            if (!c2.atk.Equals(-1))
            {
                flag = c1.atk.Equals(c2.atk);
            }
            if (flag.Equals(false))
            {
                return false;
            }
            //判断卡牌守备力
            if (!c2.def.Equals(-1))
            {
                flag = c1.def.Equals(c2.def);
            }
            if (flag.Equals(false))
            {
                return false;
            }
            //判断卡牌效果文本
            if (!c2.effectText.Equals(""))
            {
                flag = c1.effectText.Equals(c2.effectText);
            }
            if (flag.Equals(false))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 重载Card类 “！=”符号，实例2的属性字段为否决值的不进行判断。
        /// </summary>
        /// <param name="c1">Card类实例1</param>
        /// <param name="c2">Card类实例2</param>
        /// <returns>“！=”比较结果的bool值</returns>
        public static bool operator !=(Card c1, Card c2)
        {
            return !(c1 == c2);
        }
        
    }

}


