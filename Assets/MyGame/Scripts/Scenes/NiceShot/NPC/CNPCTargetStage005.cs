using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNPCTargetStage005 : CNPCBase
{
    public override EActorType MyActorType() { return EActorType.eTarget; }

    protected override void AddInitState()
    {
        m_AllState[(int)StaticGlobalDel.EMovableState.eWait].AllThisState.Add(new CWaitStateBase(this));
        m_AllState[(int)StaticGlobalDel.EMovableState.eWait].AllThisState.Add(new CWaitStateBase(this));
        m_AllState[(int)StaticGlobalDel.EMovableState.eDeath].AllThisState.Add(new CDeathStateNPC_Target(this));
        //m_AllState[(int)StaticGlobalDel.EMovableState.eWin].AllThisState.Add(new CWinStateNPC_S04(this));

        AddBuff();
    }
}
