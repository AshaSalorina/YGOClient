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

            Options.isRoomMaster = true;
            Options.Room = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\Room\Room"), Options.MainCanvas, MathCommonData.ZVector3, MathCommonData.EVector3, "Room", true);


            Options.GameCenter.SetActive(false);
        }

        public static void JoinRoom(Room rm)
        {

            Options.isRoomMaster = false;
            Options.Room = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\Room\Room"), Options.MainCanvas, MathCommonData.ZVector3, MathCommonData.EVector3, "Room", true);

            Options.GameCenter.SetActive(false);
        }


        public static void LeaveRoom()
        {
            Options.GameCenter.SetActive(true);
            GameObject.Destroy(Options.Room);
        }

    }
}

