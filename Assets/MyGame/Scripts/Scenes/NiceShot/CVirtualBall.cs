using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;

public class CVirtualBall : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        CDataJumpBounce lTempDataJumpBounce = other.gameObject.GetComponent<CDataJumpBounce>();

        if (lTempDataJumpBounce == null)
            return;

        m_CallBackDataJumpBounce.OnNext(lTempDataJumpBounce);
    }

    public UniRx.Subject<CDataJumpBounce> m_CallBackDataJumpBounce = new UniRx.Subject<CDataJumpBounce>();

    public UniRx.Subject<CDataJumpBounce> ObserverCallBackDataJumpBounceEvent()
    {
        return m_CallBackDataJumpBounce ?? (m_CallBackDataJumpBounce = new UniRx.Subject<CDataJumpBounce>());
    }
}
