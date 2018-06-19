using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYJ.Models;

namespace HYJ.Controllers
{
    public class ChainControl
    {
        /// <summary>
        /// 连锁开始,返回为null表示未成功
        /// </summary>
        /// <param name="g">Game类对象</param>
        static public List<Chain> ChainStart(Game g)
        {
            if (g.isChain == true)//如果有连锁了，就不能再开连锁
            {
                return null;
            }
            if (g.chains.Count != 0)//如果连锁中还有未清除的项 应该清除掉
            {
                g.chains.Clear();
            }
            g.isChain = true;

            return g.chains;
        }
        /// <summary>
        /// 连锁结束
        /// </summary>
        /// <param name="g">Game类对象</param>
        static public void ChainEnd(Game g)
        {
            g.chains.Clear();
            g.isChain = false;
        }
        /// <summary>
        /// 连锁发动
        /// </summary>
        /// <param name="g">Game类对象</param>
        static public void ChainLuanch(Game g)
        {
            //待写
        }

    }
}
