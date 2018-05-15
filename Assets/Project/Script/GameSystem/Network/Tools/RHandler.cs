using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Tools
{
    /// <summary>
    /// 响应状态类型枚举
    /// </summary>
    enum StatusType
    {
        SUCCESS,
        ERROR
    }

    /// <summary>
    /// 数据载体处理类
    /// </summary>
    public class RHandler
    {
        /// <summary>
        /// 响应类型
        /// </summary>
        private StatusType type;

        /// <summary>
        /// 响应中文信息
        /// </summary>
        private string msg;

        public RHandler(R status)
        {
            
        }

        private string ConvertChiness(int code)
        {
            switch (code)
            {
                case 200: return "成功";
                case 500: return "错误";
                default:
                    return "未知错误";
            }
        }
    }
}
