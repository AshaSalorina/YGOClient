using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.Tools
{
    /// <summary>
    /// 设定目标的地址
    /// </summary>
    public class PositionHelper
    {
        public enum Where
        {
            Local,
            Global
        }
        /// <summary>
        /// 单纯设置坐标，这个方法没有原来的好用，待改进
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="vector"></param>
        /// <param name="wh"></param>
        public static void SetPosition(GameObject obj, Vector3 vector, Where wh = Where.Local)
        {
            switch (wh)
            {
                case Where.Local:
                    obj.transform.localPosition = vector;
                    break;
                case Where.Global:
                    obj.transform.position = vector;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 添加坐标，这个方法没有原来的好用，待改进
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="vector"></param>
        /// <param name="wh"></param>
        public static void AddVector(GameObject obj, Vector3 vector, Where wh = Where.Local)
        {
            switch (wh)
            {
                case Where.Local:
                    obj.transform.localPosition += vector;
                    break;
                case Where.Global:
                    obj.transform.position += vector;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 当投入参数为0，则不改变坐标，否则设定其对应位
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="v3"></param>
        /// <param name="wh"></param>
        public static void BecomeVector(GameObject obj, Vector3 v3, Where wh = Where.Local)
        {
            var vt = new Vector3();
            switch (wh)
            {
                case Where.Local:
                    vt = CombineVector(obj.transform.localPosition, v3);
                    break;
                case Where.Global:
                    vt = CombineVector(obj.transform.position, v3);
                    break;
                default:
                    break;
            }

            SetPosition(obj, vt, wh);
        }
        /// <summary>
        /// 组合两个向量，以第一个向量为基础，把第二个向量的非零部分填充上去
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3 CombineVector(Vector3 v1, Vector3 v2)
        {
            var vt = new Vector3();
            vt.x = v2.x != 0 ? v2.x : v1.x;
            vt.y = v2.y != 0 ? v2.y : v1.y;
            vt.z = v2.z != 0 ? v2.z : v1.z;
            return vt;
        }
    }




}


