using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDeathStateNPCBase : CNPCS04StateBase
{
    public override EMovableState StateType() { return EMovableState.eDeath; }

    public CDeathStateNPCBase(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {
        m_MyNPCMemoryShare.m_MyActor.EnabledRagdoll(true);
    }

    protected override void updataState()
    {
        if (MomentinTime(0.5f))
            m_MyGameManager.SetState(CGameManager.EState.eGameOver);

        base.updataState();
    }

    protected override void OutState()
    {

    }
}
