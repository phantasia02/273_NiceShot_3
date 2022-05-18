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
    }

    protected override void updataState()
    {
        base.updataState();
    }

    protected override void OutState()
    {

    }
}
