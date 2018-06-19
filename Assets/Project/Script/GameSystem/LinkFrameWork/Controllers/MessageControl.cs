using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYJ.Models;

namespace HYJ.Controllers
{
    /// <summary>
    /// 消息控制类
    /// </summary>
    public class MessageControl
    {
        /// <summary>
        /// 消息处理系统
        /// </summary>
        /// <param name="m"></param>
        static public void MessageSystem(Message m)
        {
            
        }
        /// <summary>
        /// 获取消息
        /// </summary>
        /// <param name="m">消息</param>
        static public void Get(Message m)
        {
            switch (m.messageClass)
            {
                case MessageEnum.ActionMessage://操作
                    Rule.Luanch(m);
                    break;
                case MessageEnum.EffectMessage://效果
                    //
                    break;
                case MessageEnum.SystemMessage://系统
                    //
                    break;
                case MessageEnum.RoundMessage://回合
                    Rule.Luanch(m);
                    break;
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender">消息发送者</param>
        /// <param name="desc">消息描述</param>
        /// <param name="content">消息内容</param>
        /// <param name="messageEnum">消息类型</param>
        static public void Send(ControllerEnum sender, string desc, string[] content, MessageEnum messageEnum)
        {
            Message m = null;
            string str = "";
            switch (messageEnum)
            {
                case MessageEnum.ActionMessage://操作消息
                    str = Rule.GetPlayerName(sender) + desc + Rule.GetDuelCard( int.Parse(content[1]));
                    m = new Message(sender, messageEnum, str);
                    m.content = content ;
                    break;
                case MessageEnum.EffectMessage://效果消息
                    //待处理
                    break;
                case MessageEnum.RoundMessage://回合消息
                    if (desc == "进入回合阶段")
                    {
                        switch (Rule.g.stage)
                        {
                            case 1:
                                str = desc + "抽卡阶段";
                                break;
                            case 2:
                                str = desc + "主阶段1";
                                break;
                            case 3:
                                str = desc + "战斗阶段";
                                break;
                            case 4:
                                str = desc + "主阶段2";
                                break;
                            case 5:
                                str = desc + "结束阶段";
                                break;
                            case 6:
                                str = desc + "准备阶段";
                                break;
                        }
                    }
                    else
                    {
                        str = desc + (Rule.g.round + 1).ToString();
                    }
                    m = new Message(sender, messageEnum, str);
                    m.content = content;
                    break;
                case MessageEnum.SystemMessage://系统消息

                    break;
            }
        }


    }
}
