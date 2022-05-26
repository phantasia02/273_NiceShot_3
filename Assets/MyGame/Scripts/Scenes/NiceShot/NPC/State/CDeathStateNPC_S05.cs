using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDeathStateNPC_S05 : CNPCS04StateBase
{
    public override EMovableState StateType() { return EMovableState.eDeath; }

    public CDeathStateNPC_S05(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {

        m_MyNPCMemoryShare.m_MyActor.EnabledRagdoll(true);


    }

    protected override void updataState()
    {
        if (MomentinTime(1.0f))
            m_MyGameManager.SetState(CGameManager.EState.eGameOver);

        base.updataState();
    }

    protected override void OutState()
    {

    }
}
