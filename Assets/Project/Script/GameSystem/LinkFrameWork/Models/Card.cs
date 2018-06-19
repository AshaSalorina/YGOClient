using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 作者：HYJ
/// 创建时间：5.12
/// 创建内容：Card类及其扩展类
/// 最后修改：5.19
/// 修改内容：1.Card类构造函数重载
///                  2.Card类重载 “ = = ”符号，“！=”符号
///                  3.Card类增加字段 race
///                  4.Card类完成所有属性封装
///                  5.Card类完成 转译卡牌种类、卡牌种族的方法
///                  6.Card类完成 卡牌简介方法
///                  7.Card类增加了 魔法卡&陷阱卡的缺省复原
/// 待办事项：1.DuelCard类
///                  2.Player类
///                  3.Rule类
///                  4.RuleInfo类
///                  5.Game类
///                  6.CardEnum类
/// </summary>
namespace HYJ.Models
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
        /// 卡牌种族。否决值 -1
        /// </summary>
        protected int race = -1;
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
        /// <summary>
        /// 卡牌转译后种族。 否决值 ""
        /// </summary>
        protected string translatedRace = "";

        /// <summary>
        /// Card类构造函数，无参数默认构造
        /// </summary>
        public Card()
        {
            //为空
        }
        /// <summary>
        /// Card类构造函数，无指定卡牌规则名称.属性全为string类型
        /// </summary>
        /// <param name="cId">卡牌id</param>
        /// <param name="cName">卡牌名称</param>
        /// <param name="cLevel">卡牌星级</param>
        /// <param name="cAttribute">卡牌属性</param>
        /// <param name="cType">卡牌种类（16进制）</param>
        /// <param name="cRace">卡牌种族（16进制）</param>
        /// <param name="cAtk">卡牌攻击力</param>
        /// <param name="cDef">卡牌守备力</param>
        /// <param name="cEffectText">卡牌效果文本</param>
        public Card(string cId, string cName, string cLevel, string cAttribute, string cType, string cRace, string cAtk, string cDef, string cEffectText)
        {
            this.id = int.Parse(cId);
            this.name = cName;
            this.ruleName = cName;
            this.level = int.Parse(cLevel);
            this.attribute = int.Parse(cAttribute);
            this.type = int.Parse(cType);
            this.race = int.Parse(cRace);
            this.atk = int.Parse(cAtk);
            this.def = int.Parse(cDef);
            this.effectText = cEffectText;

            this.translatedAttribute = TranslaleAttribute(cAttribute);
            this.translatedType = TranslateType(cType);
            this.translatedRace = TranslateRace(cRace);
            DefaultCard();
        }
        /// <summary>
        /// Card类构造函数,有指定卡牌规则名称，属性全为string类型
        /// </summary>
        /// <param name="cId">卡牌id</param>
        /// <param name="cName">卡牌名称</param>
        /// <param name="cRuleName">卡牌规则名称</param>
        /// <param name="cLevel">卡牌星级</param>
        /// <param name="cAttribute">卡牌属性</param>
        /// <param name="cType">卡牌种类(16进制)</param>
        /// <param name="cRace">卡牌种族（16进制）</param>
        /// <param name="cAtk">卡牌攻击力</param>
        /// <param name="cDef">卡牌守备力</param>
        /// <param name="cEffectText">卡牌效果文本</param>
        public Card(string cId, string cName, string cRuleName, string cLevel, string cAttribute, string cType, string cRace, string cAtk, string cDef, string cEffectText)
        {
            this.id = int.Parse(cId);
            this.name = cName;
            this.ruleName = cRuleName;
            this.level = int.Parse(cLevel);
            this.attribute = int.Parse(cAttribute);
            this.type = int.Parse(cType);
            this.race = int.Parse(cRace);
            this.atk = int.Parse(cAtk);
            this.def = int.Parse(cDef);
            this.effectText = cEffectText;

            this.translatedAttribute = TranslaleAttribute(cAttribute);
            this.translatedType = TranslateType(cType);
            this.translatedRace = TranslateRace(cRace);
            DefaultCard();
        }

        /// <summary>
        /// 转译属性为字符串
        /// </summary>
        /// <param name="cAttribute">卡牌属性代码</param>
        /// <returns>卡牌属性字符串</returns>
        public string TranslaleAttribute(string cAttribute)
        {
            string attri = "";
            switch (cAttribute)
            {
                case "1":
                    attri = "地";
                    break;
                case "2":
                    attri = "水";
                    break;
                case "4":
                    attri = "炎";
                    break;
                case "8":
                    attri = "风";
                    break;
                case "10":
                    attri = "光";
                    break;
                case "20":
                    attri = "暗";
                    break;
                case "40":
                    attri = "神";
                    break;
                default:
                    break;
            }

            return attri;
        }
        /// <summary>
        /// 转译种类为字符串
        /// </summary>
        /// <param name="cType">卡牌种类代码</param>
        /// <returns>卡牌种类字符串</returns>
        public string TranslateType(string cType)
        {
            string strType = "";
            if (cType.Last() == '1')
            {
                switch (cType)
                {
                    case "11":
                        strType = "[通常]";
                        break;
                    case "21":
                        strType = "[效果]";
                        break;
                    case "41":
                        strType = "[融合]";
                        break;
                    case "81":
                        strType = "[仪式]";
                        break;
                    case "61":
                        strType = "[效果/融合]";
                        break;
                    ////case "A1":
                    ////    strType = "[效果/仪式]";
                    //    break;
                    case "200021":
                        strType = "[效果/反转]";
                        break;
                    case "2000021":
                        strType = "[效果/特殊召唤]";
                        break;
                    default:
                        break;
                }
            }
            else if (cType.Last() == '2')
            {
                switch (cType)
                {
                    case "2":
                        strType = "通常";
                        break;
                    case "10002":
                        strType = "速攻";
                        break;
                    case "20002":
                        strType = "永续";
                        break;
                    case "40002":
                        strType = "装备";
                        break;
                    case "80002":
                        strType = "场地";
                        break;
                    case "82":
                        strType = "仪式";
                        break;
                    default:
                        break;
                }
            }
            else if (cType.Last() == '4')
            {
                switch (cType)
                {
                    case "4":
                        strType = "通常";
                        break;
                    case "20004":
                        strType = "永续";
                        break;
                    case "10004":
                        strType = "反击";
                        break;
                    default:
                        break;
                }
            }

            return strType;
        }
        /// <summary>
        /// 转译种族为字符串
        /// </summary>
        /// <param name="cRace">卡牌种类代码</param>
        /// <returns>种族字符串</returns>
        public string TranslateRace(string cRace)
        {
            string strRace = "";
            switch (cRace)
            {
                case "1": strRace = "战士"; break;
                case "2": strRace = "魔法师"; break;
                case "4": strRace = "天使"; break;
                case "8": strRace = "恶魔"; break;
                case "10": strRace = "不死"; break;
                case "20": strRace = "机械"; break;
                case "40": strRace = "水"; break;
                case "80": strRace = "炎"; break;
                case "100": strRace = "岩石"; break;
                case "200": strRace = "鸟兽"; break;
                case "400": strRace = "植物"; break;
                case "800": strRace = "昆虫"; break;
                case "1000": strRace = "雷"; break;
                case "2000": strRace = "龙"; break;
                case "4000": strRace = "兽"; break;
                case "8000": strRace = "兽战士"; break;
                case "10000": strRace = "恐龙"; break;
                case "20000": strRace = "鱼"; break;
                case "40000": strRace = "海龙"; break;
                case "80000": strRace = "爬虫类"; break;
                case "100000": strRace = "念动力"; break;
                case "200000": strRace = "幻神兽"; break;
                case "400000": strRace = "创造神"; break;
                case "800000": strRace = "幻龙"; break;
                case "10000000": strRace = "电子界"; break;
                default:
                    break;
            }
            return strRace;
        }
        /// <summary>
        /// 显示卡牌简介
        /// </summary>
        /// <returns>卡牌简介字符串</returns>
        public string CardSummary()
        {
            string str = "";
            if (this.type % 10 == 1)//怪兽卡
            {
                str = this.translatedType + " " + this.translatedAttribute + "/" + this.translatedRace + "/" + this.level.ToString() + "★";
            }
            else//魔法卡&陷阱卡
            {
                str = this.translatedType;
            }

            return str;
        }
        /// <summary>
        /// 针对卡牌类型，复原缺省值。
        /// </summary>
        protected void DefaultCard()
        {
            if (this.type % 10 == 2 | this.type %10 == 4)
            {
                this.level = -1;
                this.attribute = -1;
                this.atk = -1;
                this.def = -1;
                this.race = -1;
            }
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
            //判断卡牌种族
            if (!c2.race.Equals(-1))
            {
                flag = c1.race.Equals(c2.race);
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

        /// <summary>
        /// 获取卡牌id
        /// </summary>
        public int GetId { get { return this.id; } }
        ///// <summary>
        ///// 设置卡牌id
        ///// </summary>
        //public int SetId { set => this.id = value; }
        /// <summary>
        /// 获取卡牌名称
        /// </summary>
        public string GetName { get { return this.name; } }
        ///// <summary>
        ///// 设置卡牌名称
        ///// </summary>
        //public string SetName { set => this.name = value; }
        /// <summary>
        /// 获取卡牌规则名称
        /// </summary>
        public string GetRuleName { get { return this.ruleName; } }
        ///// <summary>
        ///// 设置卡牌规则名称
        ///// </summary>
        //public string SetRuleName { set => this.ruleName = value; }
        /// <summary>
        /// 获取卡牌属性
        /// </summary>
        public int GetAttribute { get { return this.attribute; } }
        ///// <summary>
        ///// 设置卡牌属性
        ///// </summary>
        //public int SetAttribute { set => this.attribute = value; }
        /// <summary>
        /// 获取卡牌星级
        /// </summary>
        public int GetLevel { get { return this.level; } }
        ///// <summary>
        ///// 设置卡牌星级
        ///// </summary>
        //public int SetLevel { set => this.level = value; }
        /// <summary>
        /// 获取卡牌种类
        /// </summary>
        public int GetCardType { get { return this.type; } }
        /// <summary>
        /// 设置卡牌种类
        /// </summary>
        //public int SetCardType { set => this.type = value; }
        ///// <summary>
        /// 获取卡牌种族
        /// </summary>
        public int GetRace { get { return this.race; } }
        ///// <summary>
        ///// 设置卡牌种族
        ///// </summary>
        //public int SetRace { set => this.race = value; }
        /// <summary>
        /// 获取卡牌攻击力
        /// </summary>
        public int GetAtk { get { return this.atk; } }
        ///// <summary>
        ///// 设置卡牌攻击力
        ///// </summary>
        //public int SetAtk { set => this.atk = value; }
        /// <summary>
        /// 获取卡牌守备力
        /// </summary>
        public int GetDef { get { return this.def; } }
        /// <summary>
        /// 设置卡牌守备力
        /// </summary>
        //public int SetDef { set => this.def = value; }
        ///// <summary>
        /// 获取卡牌效果文本
        /// </summary>
        public string GetEffectText { get { return this.effectText; } }
        /// <summary>
        /// 获取转译后卡牌属性
        /// </summary>
        public string GetStrAttribute { get { return this.translatedAttribute; } }
        /// <summary>
        /// 获取转译后卡牌种类
        /// </summary>
        public string GetStrType { get { return this.translatedType; } }
        /// <summary>
        /// 获取转移后卡牌种族
        /// </summary>
        public string GetStrRace { get { return this.translatedRace; } }


    }
}
