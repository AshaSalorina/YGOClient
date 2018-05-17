using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYJ
{
    /// <summary>
    /// Field枚举类，卡牌所在区域
    /// </summary>
    enum Field
    {
        MainDeck,           //主卡组区域
        ExtraDeck,           //额外卡组区域
        Hand,                  //手牌区域
        MainMonster,     //主怪兽区域
        ExtraMonster,     //额外怪兽区域
        SpellorTrap,       //魔法陷阱卡区域
        Cemetery,          //墓地区域
        Except               //除外区域
    }
}
