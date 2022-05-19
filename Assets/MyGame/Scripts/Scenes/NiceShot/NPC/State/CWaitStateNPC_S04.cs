using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWaitStateNPC_S04 : CNPCS04StateBase
{
    public override EMovableState StateType() { return EMovableState.eWait; }

    public CWaitStateNPC_S04(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {

        m_MyNPCMemoryShare.m_MyNPCStage004.AddBuff(CMovableBuffPototype.EMovableBuff.eScared);

    }

    protected override void updataState()
    {
        base.updataState();
    }

    protected override void OutState()
    {
        m_MyNPCMemoryShare.m_MyNPCStage004.ERemoveBuff(CMovableBuffPototype.EMovableBuff.eScared);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == StaticGlobalDel.TagPlayer)
            ChangState(EMovableState.eDeath);
    }
}
