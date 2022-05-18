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
    }

    protected override void updataState()
    {
        base.updataState();
    }

    protected override void OutState()
    {
       
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == StaticGlobalDel.TagPlayer)
            ChangState(EMovableState.eDeath);
    }
}
