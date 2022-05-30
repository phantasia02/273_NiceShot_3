using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJumpStateNPC_S06 : CNPCS04StateBase
{
    public override EMovableState StateType() { return EMovableState.eJump; }

    protected CNPCTargetStage006 m_MyMovable = null;
    protected Transform m_NextPosTransform = null;

    public CJumpStateNPC_S06(CMovableBase pamMovableBase) : base(pamMovableBase)
    {
        m_MyMovable = (CNPCTargetStage006)m_MyNPCMemoryShare.m_MyMovable;
        m_NextPosTransform = m_MyMovable.NextPos;
    }

    protected override void InState()
    {
        Transform lTempTargetTransform = m_MyMovable.AllRefPos[Random.Range(0, m_MyMovable.AllRefPos.Count)];
        lTempTargetTransform.Rotate(Vector3.up * Random.Range(0.0f, 360.0f));

        m_MyMovable.TargetPos = lTempTargetTransform;

        Vector3 lTempRandomPos = Random.insideUnitCircle;
        lTempRandomPos.y += 2.0f;
        m_NextPosTransform.position = lTempTargetTransform.position + lTempRandomPos;
       // m_NextPosTransform.Rotate(Random.insideUnitCircle * 360.0f);
    }

    protected override void updataState()
    {
        base.updataState();

        Vector3 lTempDir = m_NextPosTransform.position - m_MyNPCMemoryShare.m_MyTransform.position;
        lTempDir.Normalize();

        m_MyNPCMemoryShare.m_MyTransform.Translate(0.0f, 0.0f, Time.deltaTime * (10.0f - Mathf.Min(8.0f, 2.0f * m_StateTime)));
        m_MyNPCMemoryShare.m_MyTransform.forward = Vector3.Lerp(m_MyNPCMemoryShare.m_MyTransform.forward, lTempDir, Time.deltaTime * ((m_StateTime * 2.0f) + 5.0f));

        
        if (Vector3.Distance(m_MyNPCMemoryShare.m_MyTransform.position, m_NextPosTransform.position) <= 0.5f)
            ChangState(EMovableState.eJumpDown);
    }

    protected override void OutState()
    {
    }
}
