using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CNPCTargetStateBase006 : CNPCS04StateBase
{
    public CNPCTargetStateBase006(CMovableBase pamMovableBase) : base(pamMovableBase)
    {
        m_MyNPCMemoryShare = (CNPCBaseMemoryShare)m_MyMemoryShare;
    }

    public override void OnTriggerEnter(Collider other)
    {

        if (m_MyNPCMemoryShare.m_MyMovable.ChangState != EMovableState.eMax)
            return;


        CMovableBase lTempMovableBase = other.GetComponentInParent<CMovableBase>();

        if (lTempMovableBase == null)
            return;

        if (lTempMovableBase.MyMovableType() != CMovableBase.EMovableType.eBullet)
            return;


        ChangState(EMovableState.eDeath);
        UseTirgger(false);
        UseGravityRigidbody(true);


        Vector3 lTempvector3 = other.transform.forward;
        lTempvector3.y += 0.5f;
        lTempvector3.Normalize();
        m_MyNPCMemoryShare.m_MyRigidbody.AddForce(lTempvector3 * 5.0f, ForceMode.VelocityChange);
    }
}
