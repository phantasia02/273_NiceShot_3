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
        m_MyNPCMemoryShare.m_MyNPCStage004.AddBuff(CMovableBuffPototype.EMovableBuff.eWeep);
    }

    protected override void updataState()
    {
        base.updataState();
    }

    protected override void OutState()
    {
        m_MyNPCMemoryShare.m_MyNPCStage004.ERemoveBuff(CMovableBuffPototype.EMovableBuff.eWeep);
    }
}
