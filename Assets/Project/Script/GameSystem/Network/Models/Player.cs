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
        private bool isSP= false;

        [DataMember(Name = "fg")]
        private bool finger;

        public Player() { }

        public override string ToString()
        {
            return name;
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
        /// 玩家是否已进入开始\准备状态
        /// </summary>
        public bool IsPrepared
        {
            get
            {
                return isSP;
            }

            set
            {
                isSP = value;
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
