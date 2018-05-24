using System;
using System.Runtime.Serialization;

namespace Egan.Models
{
    /// <summary>
    /// 玩家类
    /// </summary>
    [DataContract]
    public class Player
    {
        
        [DataMember(Name = "nm")]
        private String name;

        
        [DataMember(Name = "hd")]
        private string head;

        
        [DataMember(Name = "isp")]
        private bool isPrepared = false;

        
        [DataMember(Name = "iss")]
        private bool isStarting = false;

        [DataMember(Name = "fg")]
        private bool finger;

        public Player() { }

        public Player(string name, string head, bool isPrepared, bool isStarting)
        {
            this.name = name;
            this.head = head;
            this.isPrepared = isPrepared;
            this.isStarting = isStarting;
        }

        /// <summary>
        /// 玩家名
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        /// <summary>
        /// 玩家头像图片
        /// </summary>
        public string Head
        {
            get
            {
                return head;
            }

            set
            {
                head = value;
            }
        }

        /// <summary>
        /// 玩家（房客）是否已进入准备状态
        /// </summary>
        public bool IsPrepared
        {
            get
            {
                return isPrepared;
            }

            set
            {
                isPrepared = value;
            }
        }

        /// <summary>
        /// 玩家（房主）是否已经进入开始状态
        /// </summary>
        public bool IsStarted
        {
            get
            {
                return isStarting;
            }

            set
            {
                isStarting = value;
            }
        }

        /// <summary>
        /// 猜拳
        /// </summary>
        public bool Finger
        {
            get
            {
                return finger;
            }

            set
            {
                finger = value;
            }
        }
    }
}
