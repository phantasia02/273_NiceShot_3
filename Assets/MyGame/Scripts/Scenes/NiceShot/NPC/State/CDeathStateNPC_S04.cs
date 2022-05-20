using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDeathStateNPC_S04 : CNPCS04StateBase
{
    public override EMovableState StateType() { return EMovableState.eDeath; }

    public CDeathStateNPC_S04(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {

        m_MyNPCMemoryShare.m_MyActor.EnabledRagdoll(true);

        IGameObjOpenGravity[] lTempAllTargetObj = m_MyNPCMemoryShare.m_MyActor.GetComponentsInChildren<IGameObjOpenGravity>();

        foreach (var item in lTempAllTargetObj)
            item.OpenGravity(true);
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
