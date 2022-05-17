using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;

public class CVirtualBall : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        //CDataJumpBounce lTempDataJumpBounce = other.gameObject.GetComponent<CDataJumpBounce>();

        //if (lTempDataJumpBounce == null)
        //    return;

        m_CallBackDataJumpBounce.OnNext(other.gameObject);
    }

    public UniRx.Subject<GameObject> m_CallBackDataJumpBounce = new UniRx.Subject<GameObject>();

    public UniRx.Subject<GameObject> ObserverCallBackDataJumpBounceEvent()
    {
        return m_CallBackDataJumpBounce ?? (m_CallBackDataJumpBounce = new UniRx.Subject<GameObject>());
    }
}
