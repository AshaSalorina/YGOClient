using Egan.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asha.Tools;


namespace Asha
{
    public class RoomInfo
    {

        public static void CreatRoom(Room rm)
        {
            Options.GameCenter.SetActive(false);
            Options.isRoomMaster = true;
            Options.Room = InstantiateHelper.InsObj(Resources.Load<GameObject>(""), Options.MainCanvas, MathCommonData.ZVector3, MathCommonData.EVector3, "Room", true);
        }

        public static void JoinRoom(Room rm)
        {
            Options.GameCenter.SetActive(false);
            Options.isRoomMaster = false;
            Options.Room = InstantiateHelper.InsObj(Resources.Load<GameObject>(""), Options.MainCanvas, MathCommonData.ZVector3, MathCommonData.EVector3, "Room", true);
        }


        public static void LeaveRoom()
        {
            Options.GameCenter.SetActive(true);
            GameObject.Destroy(Options.Room);
        }

    }
}

