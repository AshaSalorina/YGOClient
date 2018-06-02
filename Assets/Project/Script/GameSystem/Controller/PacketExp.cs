using Asha.Tools;
using Egan.Constants;
using Egan.Models;
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
        return JsonConvert.DeserializeObject<List<Room>>(job["rm"].ToString());
    }

    /// <summary>
    /// 解释房主收到的join消息,返回房客信息
    /// </summary>
    /// <param name="dp"></param>
    /// <returns></returns>
    public static Player ExpHJoin(DataPacket dp)
    {
        return JsonConvert.DeserializeObject<Player>(dp.Body);
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

}
