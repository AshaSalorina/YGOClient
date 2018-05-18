using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asha.Tools;
using UnityEngine.EventSystems;

namespace Asha
{
    /// <summary>
    /// 主界面中三个小按钮的移动动画
    /// </summary>
    public class UI_MS_allButtonAnime : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        static Vector3 MoveSpeed = new Vector3(4, 0, 0);
        static Vector3 EndPosition = new Vector3(320, 0, 0);
        static Vector3 StartPosition = new Vector3(420, 0, 0);

        public void OnPointerEnter(PointerEventData pED)
        {
            StopAllCoroutines();
            StartCoroutine(PutIn());
        }

        public void OnPointerExit(PointerEventData pED)
        {
            StopAllCoroutines();
            StartCoroutine(PutBack());
        }

        IEnumerator PutIn()
        {
            while (Mathf.Abs(gameObject.transform.localPosition.x - 320) > 4)
            {
                MoveSpeed = Vector3.Lerp(gameObject.transform.localPosition, PositionHelper.CombineVector(gameObject.transform.localPosition, EndPosition), 0.2f);
                PositionHelper.SetPosition(gameObject, MoveSpeed);
                yield return new WaitForFixedUpdate();
            }
            PositionHelper.BecomeVector(gameObject, EndPosition);
        }

        IEnumerator PutBack()
        {
            while (Mathf.Abs(gameObject.transform.localPosition.x - 420) > 4)
            {
                MoveSpeed = Vector3.Lerp(gameObject.transform.localPosition, PositionHelper.CombineVector(gameObject.transform.localPosition, StartPosition), 0.2f);
                PositionHelper.SetPosition(gameObject, MoveSpeed);
                yield return new WaitForFixedUpdate();
            }
            PositionHelper.BecomeVector(gameObject, StartPosition);
        }

        void OnDisable()
        {
            StopAllCoroutines();
            PositionHelper.BecomeVector(gameObject, StartPosition);
        }

    }
}

