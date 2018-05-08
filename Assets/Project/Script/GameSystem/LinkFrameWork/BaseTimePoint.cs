using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BaseTimePoint();

/// <summary>
/// 所有的连锁/时点都当做触发器时点处理，这里提供时点的接口
/// </summary>
public interface IBaseTP {

    /// <summary>
    /// 基本时点事件
    /// </summary>
    event BaseTimePoint TimePoint;

    /// <summary>
    /// 时点中触发的动作
    /// </summary>
    /// <returns></returns>
    IEnumerator BaseTPBegin();

}
