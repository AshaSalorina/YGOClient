using System.Runtime.Serialization;

namespace Egan.Tools
{
    /// <summary>
    /// 数据载体类
    /// 用于描述服务器响应状态
    /// </summary>
    [DataContract]
    public class R
    {
        [DataMember]
        private int code;

        private string msg;

        public R(int code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }

        public int Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string Msg
        {
            get
            {
                return msg;
            }

            set
            {
                msg = value;
            }
        }
    }
}
