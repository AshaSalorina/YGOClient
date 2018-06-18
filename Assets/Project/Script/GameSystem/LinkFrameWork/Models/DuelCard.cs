using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using HYJ.Controllers;

namespace HYJ.Models
{
    /// <summary>
    /// DuelCard类，继承自Card类
    /// </summary>
    public class DuelCard : Card
    {
        /// <summary>
        /// 卡牌名称副本, 否决值 ""
        /// </summary>
        public string copyName = "";
        /// <summary>
        /// 卡牌规则名称副本, 否决值 ""
        /// </summary>
        public string copyRuleName = "";
        /// <summary>
        /// 卡牌星级副本, 否决值 -1
        /// </summary>
        public int copyLevel = -1;
        /// <summary>
        /// 卡牌属性副本, 否决值 -1
        /// </summary>
        public int copyAttribute = -1;
        /// <summary>
        /// 卡牌种类副本, 否决值 -1
        /// </summary>
        public int copyType = -1;
        /// <summary>
        /// 卡牌种族副本，否决值 -1
        /// </summary>
        public int copyRace = -1;
        /// <summary>
        /// 卡牌攻击力副本, 否决值 -1
        /// </summary>
        public int copyAtk = -1;
        /// <summary>
        /// 卡牌守备力副本, 否决值 -1
        /// </summary>
        public int copyDef = -1;
        /// <summary>
        /// 卡牌效果文本副本, 否决值 ""
        /// </summary>
        public string copyEffectText = "";

        /// <summary>
        /// 卡牌转译后属性副本。否决值 ""
        /// </summary>
        public string copyTranslatedAttribute = "";
        /// <summary>
        /// 卡牌转译后种类副本。否决值 ""
        /// </summary>
        public string copyTranslatedType = "";
        /// <summary>
        /// 卡牌转译后种族副本。 否决值 ""
        /// </summary>
        public string copyTranslatedRace = "";

        /// <summary>
        /// 卡牌控制者，默认值 System
        /// </summary>
        public ControllerEnum controller = ControllerEnum.System;
        /// <summary>
        /// 卡牌当前控制者，默认值 System
        /// </summary>
        public ControllerEnum currentController = ControllerEnum.System;
        /// <summary>
        /// 卡牌所在区域
        /// </summary>
        public FieldEnum field;
        /// <summary>
        /// 卡牌的编号
        /// </summary>
        public int no;
        /// <summary>
        /// 卡牌状态，默认未知状态
        /// </summary>
        public StateEnum state = StateEnum.Deck;

        ///// <summary>
        ///// 接受对方怪兽卡效果权限，默认 true
        ///// </summary>
        //private bool acceptOppMontserEffect = true;
        ///// <summary>
        ///// 接受对方魔法卡效果权限，默认 true
        ///// </summary>
        //private bool acceptOppSpellEffect = true;
        ///// <summary>
        ///// 接受对方陷阱卡效果权限，默认 true
        ///// </summary>
        //private bool acceptOppTrapEffect = true;
        ///// <summary>
        ///// 接受自己怪兽卡效果权限，默认 true
        ///// </summary>
        //private bool acceptOwnMonsterEffect = true;
        ///// <summary>
        ///// 接受自己魔法卡效果权限，默认 true
        ///// </summary>
        //private bool acceptOwnSpellEffect = true;
        ///// <summary>
        ///// 接受自己陷阱卡效果权限，默认 true
        ///// </summary>
        //private bool acceptOwnTrapEffect = true;


        /// <summary>
        /// 卡牌效果方法集合
        /// </summary>
        public Effect[] effects = null;

        /// <summary>
        /// DuelCard类构造函数，Card作为参数,Card无指定卡牌规则名称
        /// </summary>
        /// <param name="c">Card类实例</param>
        public DuelCard(Card c)
            : base(c.GetName, c.GetRuleName,
            c.GetLevel.ToString(), c.GetAttribute.ToString(), c.GetCardType.ToString(),
            c.GetRace.ToString(), c.GetAtk.ToString(), c.GetDef.ToString(), c.GetEffectText)
        {
            this.copyName = c.GetName;
            this.copyRuleName = c.GetRuleName;
            this.copyLevel = c.GetLevel;
            this.copyAttribute = c.GetAttribute;
            this.copyType = c.GetCardType;
            this.copyRace = c.GetRace;
            this.copyAtk = c.GetAtk;
            this.copyDef = c.GetDef;
            this.copyEffectText = c.GetEffectText;

            this.copyTranslatedAttribute = CopyTranslaleAttribute(this.copyAttribute.ToString());
            this.copyTranslatedType = CopyTranslateType(this.copyType.ToString());
            this.copyTranslatedRace = CopyTranslateRace(this.copyRace.ToString());

            InitialActions();
            InitialEffects();
        }

        /// <summary>
        /// 转译属性为字符串副本
        /// </summary>
        /// <param name="cAttribute">卡牌属性代码</param>
        /// <returns>卡牌属性字符串</returns>
        public string CopyTranslaleAttribute(string cAttribute)
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
        /// 转译种类为字符串副本
        /// </summary>
        /// <param name="cType">卡牌种类代码</param>
        /// <returns>卡牌种类字符串</returns>
        public string CopyTranslateType(string cType)
        {
            string strType = "";
            if (cType.Last() == '1')//怪兽卡
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
                    case "A1":
                        strType = "[效果/仪式]";
                        break;
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
            else if (cType.Last() == '2')//魔法卡
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
            else if (cType.Last() == '4')//陷阱卡
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
        /// 转译种族为字符串副本
        /// </summary>
        /// <param name="cRace">卡牌种类代码</param>
        /// <returns>种族字符串</returns>
        public string CopyTranslateRace(string cRace)
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
        /// 显示卡牌简介副本，
        /// 如：[通常]/龙/光/8★
        /// </summary>
        /// <returns>卡牌简介字符串</returns>
        public string CopyCardSummary()
        {
            string str = "";
            if (this.type % 10 == 1)//怪兽卡
            {
                str = this.copyTranslatedType + " " + this.copyTranslatedAttribute + "/" + this.copyTranslatedRace + "/" + this.copyLevel.ToString() + "★";
            }
            else//魔法卡&陷阱卡
            {
                str = this.copyTranslatedType;
            }

            return str;
        }

        /// <summary>
        /// 初始化DuelCard
        /// </summary>
        public void InitialDuelCard()
        {
            this.copyName = this.name;
            this.copyRuleName = this.ruleName;
            this.copyLevel = this.level;
            this.copyAttribute = this.attribute;
            this.copyType = this.type;
            this.copyRace = this.race;
            this.copyAtk = this.atk;
            this.copyDef = this.def;
            this.copyEffectText = this.effectText;

            this.copyTranslatedAttribute = CopyTranslaleAttribute(this.copyAttribute.ToString());
            this.copyTranslatedType = CopyTranslateType(this.copyType.ToString());
            this.copyTranslatedRace = CopyTranslateRace(this.copyRace.ToString());


        }
        /// <summary>
        /// 初始化卡牌效果方法
        /// </summary>
        public void InitialEffects()
        {
            //string dllPath = "/LinkFrameWork/" + this.GetId.ToString() + ".dll";
            //Assembly asm = Assembly.LoadFile(dllPath);
            //string classPath = "_" + this.GetId.ToString() + "._" + this.GetId.ToString();
            //Type t = asm.GetType(classPath);

            if (this.copyType == 11 | this.copyType == 41 | this.copyType == 81)
            {
                this.effects = null;
            }
            else
            {
                //暂时不写效果怪兽
                this.effects = null;
            }
        }
        /// <summary>
        /// 初始化卡牌操作方法集合
        /// </summary>
        public void InitialActions()
        {
            Effect e1 = Rule.CreatNormalSummonAction(this);//通常召唤操作
            Effect e2 = Rule.CreatSetSummonAction(this);//前场放置操作
            Effect e3 = Rule.CreatSuperiorSummonAction(this);//上级召唤操作
            Effect e4 = Rule.CreatChangeFromAction(this);//改变表侧形式操作
            Effect e5 = Rule.CreatAttackAction(this);//未完成
            Effect e6 = Rule.CreatSetAction(this);//后场放置操作
            Effect e7 = Rule.CreatFlipSummonAction(this);//反转召唤操作
            
            switch (this.copyType)
            {
                case 11://[通常]
                    this.effects = new Effect[] { e1, e2, e3, e4, e5 };
                    break;
                case 41://[融合]
                case 81://[仪式]
                    this.effects = new Effect[] { e4, e5 };
                    break;
                case 21://[效果]
                case 61://[效果/融合]
                        //case "A1"://[效果/仪式]
                        //    strType = "[效果/仪式]";
                        //break;
                case 200021://[效果/反转]
                case 2000021://[效果/特殊召唤]
                    break;

                case 2://通常
                case 10002://速攻
                case 20002://永续
                case 40002://装备
                case 80002://场地
                case 82://仪式
                    break;

                case 4://通常
                case 20004://永续
                case 10004://反击
                    break;
            }
        }
        /// <summary>
        /// 获得卡牌的可发动效果方法名集合
        /// </summary>
        public List<string> GetActionsName()
        {
            List<string> names = new List<string>();
            foreach (Effect e in this.effects)
            {
                if (e.isAction == true)//操作方法
                {
                    if (Rule.JudgeActionEffectEnableLaunch(e) == true)
                    {
                        names.Add(e.name);
                    }
                }
                else//效果方法
                {
                    if (Rule.JudgeActiveEffectEnableLaunch(e) == true)
                    {
                        names.Add(e.name);
                    }
                }

            }
            return names;
        }
        /// <summary>
        /// 获的对应方法名的效果对象,没有返回 null
        /// </summary>
        /// <param name="name">效果方法名</param>
        /// <returns></returns>
        public Effect GetEffectOfName(string name)
        {
            foreach (Effect e in this.effects)
            {
                if (e.name == name)
                    return e;
            }
            return null;
        }
        /// <summary>
        /// 找到卡牌的控制者
        /// </summary>
        /// <param name="g">Game对象</param>
        public Player FindOwnPlayer(Game g)
        {
            foreach (Player p in g.players)
            {
                if (p.GetStatus == this.currentController)
                {
                    return p;
                }
            }

            return null;
        }

        ///// <summary>
        ///// 获取卡牌名称副本
        ///// </summary>
        //public string GetCopyName { get => this.copyName; }
        ///// <summary>
        ///// 设置卡牌名称副本
        ///// </summary>
        //public string SetCopyName { set => this.copyName = value; }
        ///// <summary>
        ///// 获取卡牌规则名称副本
        ///// </summary>
        //public string GetCopyRuleName { get => this.copyRuleName; }
        ///// <summary>
        ///// 设置卡牌规则名称副本
        ///// </summary>
        //public string SetCopyRuleName { set => this.copyRuleName = value; }
        ///// <summary>
        ///// 获取卡牌星级副本
        ///// </summary>
        //public int GetCopyLevel { get => this.copyLevel; }
        ///// <summary>
        ///// 设置卡牌星级副本
        ///// </summary>
        //public int SetCopyLevel { set => this.copyLevel = value; }
        ///// <summary>
        ///// 获取卡牌属性副本
        ///// </summary>
        //public int GetCopyAttribute { get => this.copyAttribute; }
        ///// <summary>
        ///// 设置卡牌属性副本
        ///// </summary>
        //public int SetCopyAttribute { set => this.copyAttribute = value; }
        ///// <summary>
        ///// 获取卡牌种类副本
        ///// </summary>
        //public int GetCopyCardType { get => this.copyType; }
        ///// <summary>
        ///// 设置卡牌种类副本
        ///// </summary>
        //public int SetCopyCardType { set => this.copyType = value; }
        ///// <summary>
        ///// 获取卡牌种族副本
        ///// </summary>
        //public int GetCopyRace { get => this.copyRace; }
        ///// <summary>
        ///// 设置卡牌种族副本
        ///// </summary>
        //public int SetCopyRace { set => this.copyRace = value; }
        ///// <summary>
        ///// 获取卡牌攻击力副本
        ///// </summary>
        //public int GetCopyAtk { get => this.copyAtk; }
        ///// <summary>
        ///// 设置卡牌攻击力副本
        ///// </summary>
        //public int SetCopyAtk { set => this.copyAtk = value; }
        ///// <summary>
        ///// 获取卡牌守备力副本
        ///// </summary>
        //public int GetCopyDef { get => this.copyDef; }
        ///// <summary>
        ///// 设置卡牌守备力副本
        ///// </summary>
        //public int SetCopyDef { set => this.copyDef = value; }
        ///// <summary>
        ///// 获取卡牌效果文本副本
        ///// </summary>
        //public string GetCopyEffectText { get => this.copyEffectText; }
        ///// <summary>
        ///// 获取转译后卡牌属性副本
        ///// </summary>
        //public string GetStrCopyAttribute { get => this.copyTranslatedAttribute; }
        ///// <summary>
        ///// 获取转译后卡牌种类副本
        ///// </summary>
        //public string GetStrCopyType { get => this.copyTranslatedType; }
        ///// <summary>
        ///// 获取转移后卡牌种族副本
        ///// </summary>
        //public string GetStrCopyRace { get => this.copyTranslatedRace; }

        ///// <summary>
        ///// 获取控制者
        ///// </summary>
        //public ControllerEnum GetController { get => controller; }
        ///// <summary>
        ///// 设置控制者
        ///// </summary>
        //public ControllerEnum SetController { set => controller = value; }
        ///// <summary>
        ///// 获取当前控制者
        ///// </summary>
        //public ControllerEnum GetCurrentController { get => currentController; }
        ///// <summary>
        ///// 设置当前控制者
        ///// </summary>
        //public ControllerEnum SetCurrentController { set => currentController = value; }
        ///// <summary>
        ///// 获取卡牌所处区域
        ///// </summary>
        //public FieldEnum GetField { get => field; }
        ///// <summary>
        ///// 设置卡牌所处区域
        ///// </summary>
        //public FieldEnum SetField { set => field = value; }
        ///// <summary>
        ///// 获取卡牌在所处区域编号
        ///// </summary>
        //public int GetNo { get => no; }
        ///// <summary>
        ///// 设置卡牌在所在区域编号
        ///// </summary>
        //public int SetNo { set => no = value; }
        ///// <summary>
        ///// 获取卡牌状态
        ///// </summary>
        //public StateEnum GetState { get => state; }
        ///// <summary>
        ///// 设置卡牌状态
        ///// </summary>
        //public StateEnum SetState { set => state = value; }
    }
}
