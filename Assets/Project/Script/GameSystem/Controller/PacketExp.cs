using Asha.Tools;
using Egan.Constants;
using Egan.Models;
using HYJ.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 非单纯消息解析器(不能由json直接解析为类的,请调用此类来完成数据获取)
/// </summary>
public class PacketExp {

    /// <summary>
    /// 解释GetRooms消息,返回房间列表
    /// </summary>
    /// <param name="dp"></param>
    /// <returns></returns>
    public static List<Room> ExpGetRooms(DataPacket dp)
    {
        var lr = dp.Body;
        var job = JObject.Parse(lr);
        return JsonConvert.DeserializeObject<List<Room>>(job["rs"].ToString());
    }

    /// <summary>
    /// 解释房主收到的join消息,返回房客信息
    /// </summary>
    /// <param name="dp"></param>
    /// <returns></returns>
    public static Egan.Models.Player ExpHJoin(DataPacket dp)
    {
        return JsonConvert.DeserializeObject<Egan.Models.Player>(dp.Body);
    }

    /// <summary>
    /// 解释房客收到的join消息,返回房间信息
    /// </summary>
    /// <param name="dp"></param>
    /// <returns></returns>
    public static Room ExpGJoin(DataPacket dp)
    {
        return JsonConvert.DeserializeObject<Room>(dp.Body);
    }

    /// <summary>
    /// 解释创建房间
    /// </summary>
    /// <param name="dp"></param>
    /// <returns></returns>
    public static int ExpCreate(DataPacket dp)
    {
        return int.Parse(dp.Body);
    }

    /// <summary>
    /// 解释猜拳结果
    /// </summary>
    /// <param name="dp">数据包</param>
    /// <returns>输平赢(-1,0,1)</returns>
    public static int ExpFingerResult(DataPacket dp)
    {
        return int.Parse(dp.Body);
    }

    /// <summary>
    /// 解释卡组消息
    /// </summary>
    /// <param name="dp"></param>
    /// <returns></returns>
    public static List<int> ExpDeck(DataPacket dp)
    {
        List<int> deck = new List<int>();
        foreach (int card in JsonConvert.DeserializeObject<List<float>>(dp.Body))
            deck.Add(card);
        return deck;
    }

    public static int ExpCountDown(DataPacket dp)
    {
        //Debug.Log(dp.Body);
        return int.Parse(dp.Body);
    }

    public static string ExpChat(DataPacket dp)
    {
        return dp.Body;
    }

    public static Message ExpOperate(DataPacket dp)
    {
        return JsonConvert.DeserializeObject<Message>(dp.Body);
    }
}
