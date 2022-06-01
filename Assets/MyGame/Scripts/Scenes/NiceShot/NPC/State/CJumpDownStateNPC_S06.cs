using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJumpDownStateNPC_S06 : CNPCTargetStateBase006
{
    public override EMovableState StateType() { return EMovableState.eJump; }

    protected CNPCTargetStage006 m_MyCNPCTarget = null;
    protected Vector3 m_CurUpDir = Vector3.zero;


    public CJumpDownStateNPC_S06(CMovableBase pamMovableBase) : base(pamMovableBase)
    {
        m_MyMovable = (CNPCTargetStage006)m_MyNPCMemoryShare.m_MyMovable;

    }

    protected override void InState()
    {
        m_CurUpDir = m_MyNPCMemoryShare.m_MyTransform.up;
    }

    protected override void updataState()
    {
        base.updataState();

        Vector3 lTempDir = m_MyCNPCTarget.TargetPos.position - m_MyNPCMemoryShare.m_MyTransform.position;
        lTempDir.Normalize();

        m_MyNPCMemoryShare.m_MyTransform.Translate(0.0f, 0.0f, Time.deltaTime * 1.0f);
        //m_MyNPCMemoryShare.m_MyTransform.forward = Vector3.Lerp(m_MyNPCMemoryShare.m_MyTransform.forward, lTempDir, Time.deltaTime * 5.0f);
        Vector3 lTempV3 = Vector3.MoveTowards(m_MyNPCMemoryShare.m_MyTransform.position, m_MyCNPCTarget.TargetPos.position, 2.0f * Time.deltaTime);

        m_MyNPCMemoryShare.m_MyTransform.rotation = Quaternion.Lerp(m_MyNPCMemoryShare.m_MyTransform.rotation, m_MyCNPCTarget.TargetPos.rotation, Time.deltaTime * 5.0f);
        //m_MyNPCMemoryShare.m_MyTransform.up =  Vector3.Lerp(m_MyNPCMemoryShare.m_MyTransform.up, Vector3.up, Mathf.Min(Time.deltaTime * 5.0f, 1.0f));

        if (Vector3.Distance(lTempV3, m_MyCNPCTarget.TargetPos.position) <= Mathf.Epsilon)
            ChangState(EMovableState.eWait);
        else
            m_MyNPCMemoryShare.m_MyTransform.position = lTempV3;
    }

    protected override void OutState()
    {
        m_MyNPCMemoryShare.m_MyTransform.position = m_MyCNPCTarget.TargetPos.position;
        m_MyNPCMemoryShare.m_MyTransform.rotation = m_MyCNPCTarget.TargetPos.rotation;
    }


}
