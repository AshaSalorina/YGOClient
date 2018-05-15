using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Egan.Models
{
    /// <summary>
    /// 房间类
    /// </summary>
    [DataContract]
    public class Room
    {
        /// <summary>
        /// 房间ID
        /// </summary>
        private int id;

        /// <summary>
        /// 房间名称
        /// </summary>
        [DataMember(Name = "nm")]
        private string name;

        /// <summary>
        /// 房间描述
        /// </summary>
        [DataMember(Name = "ds")]
        private string desc;

        /// <summary>
        /// 房间是否存在密码
        /// </summary>
        [DataMember(Name = "hp")]
        private bool hasPwd;

        /// <summary>
        /// 房间密码
        /// </summary>
        [DataMember(Name = "ps")]
        private string password;

        /// <summary>
        /// 房间是否正在进行游戏
        /// </summary>
        [DataMember(Name = "isp")]
        private bool isPlaying;

        /// <summary>
        /// 房主
        /// </summary>
        [DataMember(Name = "hs")]
        private Player host;

        /// <summary>
        /// 客人
        /// </summary>
        [DataMember(Name = "gs")]
        private Player guest;

        public Room() { }

        public Room(int id, string name, string desc, bool hasPwd, 
            string password, bool isPlaying, Player host, Player guest)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.hasPwd = hasPwd;
            this.password = password;
            this.isPlaying = isPlaying;
            this.host = host;
            this.guest = guest;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
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

        public string Desc
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
            }
        }

        public bool HasPwd
        {
            get
            {
                return hasPwd;
            }

            set
            {
                hasPwd = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }

            set
            {
                isPlaying = value;
            }
        }

        public Player Host
        {
            get
            {
                return host;
            }

            set
            {
                host = value;
            }
        }

        public Player Guest
        {
            get
            {
                return guest;
            }

            set
            {
                guest = value;
            }
        }
    }
}
