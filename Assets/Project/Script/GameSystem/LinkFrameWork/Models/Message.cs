﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HYJ.Models
{
    /// <summary>
    /// 消息类
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 发送者
        /// </summary>
        [DataMember(Name = "sd")]
        public ControllerEnum sender;
        /// <summary>
        /// 消息类型
        /// </summary>
        [DataMember(Name = "mc")]
        public MessageEnum messageClass;
        /// <summary>
        /// 描述
        /// </summary>
        [DataMember(Name = "ds")]
        public string desdescription;
        /// <summary>
        /// 内容
        /// </summary>
        [DataMember(Name = "ct")]
        public string[] content = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="controller">发送者</param>
        /// <param name="message">消息类型</param>
        /// <param name="des">消息描述</param>
        public Message(ControllerEnum controller, MessageEnum message, string des)
        {
            this.sender = controller;
            this.messageClass = message;
            this.desdescription = des;
        }
    }
}
