using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Egan
{
    /// <summary>
    /// 玩家类
    /// </summary>
    public class Player
    {
        /// <summary>
        /// 玩家名
        /// </summary>
        private String name;

        /// <summary>
        /// 玩家头像图片
        /// </summary>
        private byte[] head;

        /// <summary>
        /// 玩家（房客）是否已进入准备状态
        /// </summary>
        private bool isPrepared;

        /// <summary>
        /// 玩家（房主）是否已经进入开始状态
        /// </summary>
        private bool isStarted;

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
                return isStarted;
            }

            set
            {
                isStarted = value;
            }
        }
    }
}
