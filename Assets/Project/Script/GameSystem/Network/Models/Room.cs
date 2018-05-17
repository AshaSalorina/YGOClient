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
        
        private int id;

        
        [DataMember(Name = "nm")]
        private string name;

        
        [DataMember(Name = "ds")]
        private string desc;

        
        [DataMember(Name = "hp")]
        private bool hasPwd;

        
        [DataMember(Name = "ps")]
        private string password;

        
        [DataMember(Name = "isp")]
        private bool isPlaying;

        
        [DataMember(Name = "hs")]
        private Player host;

        
        [DataMember(Name = "gs")]
        private Player guest;

        public override bool Equals(object obj)
        {
            return id.Equals(((Room)obj).Id);
        }

        public Room() {}

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

        /// <summary>
        /// 房间ID
        /// </summary>
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

        /// <summary>
        /// 房间名称
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
        /// 房间描述
        /// </summary>
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

        /// <summary>
        /// 房间是否存在密码
        /// </summary>
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

        /// <summary>
        /// 房间密码
        /// </summary>
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

        /// <summary>
        /// 房间是否正在进行游戏
        /// </summary>
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

        /// <summary>
        /// 房主
        /// </summary>
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

        /// <summary>
        /// 房客
        /// </summary>
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
