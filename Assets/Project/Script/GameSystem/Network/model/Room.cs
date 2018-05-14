using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Egan
{
    /// <summary>
    /// 房间类
    /// </summary>
    public class Room
    {
        /// <summary>
        /// 房间ID
        /// </summary>
        private int id;

        /// <summary>
        /// 房间名称
        /// </summary>
        private string rName;

        /// <summary>
        /// 房主名称
        /// </summary>
        private string uName;

        /// <summary>
        /// 房间描述
        /// </summary>
        private string desc;

        /// <summary>
        /// 房间是否存在密码
        /// </summary>
        private bool hasPwd;

        /// <summary>
        /// 房间密码
        /// </summary>
        private string password;

        /// <summary>
        /// 房间是否正在进行游戏
        /// </summary>
        private bool isPlaying;

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

        public string RName
        {
            get
            {
                return rName;
            }

            set
            {
                rName = value;
            }
        }

        public string UName
        {
            get
            {
                return uName;
            }

            set
            {
                uName = value;
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
    }
}
