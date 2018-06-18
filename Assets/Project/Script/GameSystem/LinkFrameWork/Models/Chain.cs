using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYJ.Models
{
    public class Chain
    {
        /// <summary>
        /// 效果参数列表, [0]是效果方法名/操作方法名,默认值 null
        /// </summary>
        public string[] effectParameter = null;
        /// <summary>
        /// 效果速度
        /// </summary>
        public int speed;
        /// <summary>
        /// 效果描述
        /// </summary>
        public string desc;
    }
}
