using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Models
{
    /// <summary>
    /// 玩家类
    /// </summary>
    [DataContract]
    public class Player
    {
        /// <summary>
        /// 玩家名
        /// </summary>
        [DataMember(Name = "nm")]
        private String name;

        /// <summary>
        /// 玩家头像图片
        /// </summary>
        [DataMember(Name = "hd")]
        private byte[] head;

        /// <summary>
        /// 玩家（房客）是否已进入准备状态
        /// </summary>
        [DataMember(Name = "isp")]
        private bool isPrepared;

        /// <summary>
        /// 玩家（房主）是否已经进入开始状态
        /// </summary>
        [DataMember(Name = "iss")]
        private bool isStarting;

        public Player() { }

        public Player(string name, byte[] head, bool isPrepared, bool isStarting)
        {
            this.name = name;
            this.head = head;
            this.isPrepared = isPrepared;
            this.isStarting = isStarting;
        }

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

        public byte[] Head
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
    }
}
