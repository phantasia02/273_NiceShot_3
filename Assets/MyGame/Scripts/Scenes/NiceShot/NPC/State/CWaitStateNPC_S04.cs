using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CWaitStateNPC_S04 : CNPCS04StateBase
{
    public override EMovableState StateType() { return EMovableState.eWait; }
    protected Tween m_ShakePosition = null;

    public CWaitStateNPC_S04(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {

        DataAddBuffInfo lTempDataAddBuffInfo = new DataAddBuffInfo();
        lTempDataAddBuffInfo.m_ListDataIndex.Add((int)CGGameSceneData.EAllFXType.eScared);
        m_MyNPCMemoryShare.m_MyNPCBase.AddBuff(CMovableBuffPototype.EMovableBuff.eExpression, lTempDataAddBuffInfo);


        m_ShakePosition = m_MyNPCMemoryShare.m_MyTransform.DOShakePosition(1.0f, strength : 0.01f, fadeOut : false).SetLoops(-1);
        //m_ExpressionObj.DOShakeRotation(1.0f, 10, 10, 90, false).SetLoops(-1).SetId(m_ExpressionObj);
    }

    protected override void updataState()
    {
        base.updataState();
    }

    protected override void OutState()
    {
        if (m_ShakePosition != null)
            m_ShakePosition.Kill();

        m_MyNPCMemoryShare.m_MyNPCBase.ERemoveBuff(CMovableBuffPototype.EMovableBuff.eExpression);
    }

    //public override void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == StaticGlobalDel.TagPlayer)
    //        ChangState(EMovableState.eDeath);
    //}
}
