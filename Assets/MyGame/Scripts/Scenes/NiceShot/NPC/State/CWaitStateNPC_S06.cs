using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWaitStateNPC_S06 : CNPCTargetStateBase006
{
    public override EMovableState StateType() { return EMovableState.eWait; }
    float m_RandomTime = 1.0f;

    public CWaitStateNPC_S06(CMovableBase pamMovableBase) : base(pamMovableBase)
    {
        m_RandomTime = Random.Range(2.5f, 4.5f);
    }

    protected override void InState()
    {
    }

    protected override void updataState()
    {
        if (MomentinTime(m_RandomTime))
             ChangState( EMovableState.eJump);


        base.updataState();
    }

    protected override void OutState()
    {
    }



}
