using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CNPCStage004MemoryShare : CMemoryShareBase
{
    public CNPCStage004 m_MyNPCMemoryShare = null;
   
};

public class CNPCStage004 : CMovableBase
{
    public override EMovableType MyMovableType() { return EMovableType.eNpc; }
    public override EObjType ObjType() { return EObjType.eNpc; }

    protected CNPCStage004MemoryShare m_MyNPCMemoryShare = null;


    protected override void AddInitState()
    {
        m_AllState[(int)StaticGlobalDel.EMovableState.eWait].AllThisState.Add(new CWaitStateNPC_S04(this));
        m_AllState[(int)StaticGlobalDel.EMovableState.eDeath].AllThisState.Add(new CDeathStateNPC_S04(this));
    }

    protected override void CreateMemoryShare()
    {
        if (m_MyMemoryShare == null)
            m_MyMemoryShare = m_MyNPCMemoryShare = new CNPCStage004MemoryShare();

        if (m_MyMemoryShare.m_MyMovable == null)
            m_MyMemoryShare.m_MyMovable = m_MyNPCMemoryShare.m_MyNPCMemoryShare = this;



        base.CreateMemoryShare();

        // ============ Skill ==================
        //m_MyPlayerMemoryShare.m_AllSkill.ListAllSkill.Add(new CPlayerChargeSkill(this));

        
    }

    protected override void Start()
    {
        base.Start();

        SetChangState(CMovableStatePototype.EMovableState.eWait);
    }
}
