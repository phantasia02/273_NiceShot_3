using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNPCStage005 : CNPCBase
{
    public override EActorType MyActorType() { return EActorType.eNPC; }

    protected override void AddInitState()
    {
        m_AllState[(int)StaticGlobalDel.EMovableState.eWait].AllThisState.Add(new CWaitStateBase(this));
        m_AllState[(int)StaticGlobalDel.EMovableState.eDeath].AllThisState.Add(new CDeathStateNPC_S05(this));
        //m_AllState[(int)StaticGlobalDel.EMovableState.eWin].AllThisState.Add(new CWinStateNPC_S04(this));

        AddBuff();
    }
}
