using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJumpStateNPC_S06 : CNPCTargetStateBase006
{
    public override EMovableState StateType() { return EMovableState.eJump; }

    protected CNPCTargetStage006 m_MyCNPCTarget = null;
    protected Transform m_NextPosTransform = null;

    public CJumpStateNPC_S06(CMovableBase pamMovableBase) : base(pamMovableBase)
    {
        m_MyCNPCTarget = (CNPCTargetStage006)m_MyNPCMemoryShare.m_MyMovable;
        m_NextPosTransform = m_MyCNPCTarget.NextPos;
    }

    protected override void InState()
    {
        Transform lTempTargetTransform = m_MyCNPCTarget.AllRefPos[Random.Range(0, m_MyCNPCTarget.AllRefPos.Count)];
        lTempTargetTransform.Rotate(Vector3.up * Random.Range(0.0f, 360.0f));


        m_MyCNPCTarget.TargetPos = lTempTargetTransform;

        Vector3 lTempRandomPos = Random.insideUnitCircle;
        lTempRandomPos.y += 2.0f;
        m_NextPosTransform.position = lTempTargetTransform.position + lTempRandomPos;
        m_NextPosTransform.Rotate(Vector3.right * Random.Range(0.0f, 360.0f));
        // m_NextPosTransform.Rotate(Random.insideUnitCircle * 360.0f);
    }

    protected override void updataState()
    {
        base.updataState();

        Vector3 lTempDir = m_NextPosTransform.position - m_MyNPCMemoryShare.m_MyTransform.position;
        lTempDir.Normalize();

        m_MyNPCMemoryShare.m_MyTransform.Translate(0.0f, 0.0f, Time.deltaTime * (5.0f - Mathf.Min(3.0f, m_StateTime)));
        m_MyNPCMemoryShare.m_MyTransform.forward = Vector3.Lerp(m_MyNPCMemoryShare.m_MyTransform.forward, lTempDir, Mathf.Min( Time.deltaTime * ((m_StateTime * 1.0f) + 3.0f), 1.0f));

        
        if (Vector3.Distance(m_MyNPCMemoryShare.m_MyTransform.position, m_NextPosTransform.position) <= 0.5f)
            ChangState(EMovableState.eJumpDown);
    }

    protected override void OutState()
    {
    }


}
