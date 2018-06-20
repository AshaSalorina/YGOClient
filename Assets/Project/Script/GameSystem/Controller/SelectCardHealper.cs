using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HYJ;
using HYJ.Models;

namespace Asha.Tools
{
    /// <summary>
    /// 选中卡牌
    /// </summary>
    public class SelectCardHealper
    {
        public static GameObject sldCard;  

        public static void SelectedCard(Card obj)
        {
            var ISCH = obj.GetType();
        }
    }

    public interface ISelectCardHealper
    {
        GameObject Card { get; }
        void SelectedCrad();
    }
}

