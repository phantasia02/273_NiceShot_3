using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CNPCStage004MemoryShare : CActorMemoryShare
{
    public CNPCStage004 m_MyNPCStage004 = null;
   
};

public class CNPCStage004 : CActor
{
    public override EActorType MyActorType() { return EActorType.eNPC; }
    protected CNPCStage004MemoryShare m_MyNPCMemoryShare = null;


    protected override void AddInitState()
    {
        m_AllState[(int)StaticGlobalDel.EMovableState.eWait].AllThisState.Add(new CWaitStateNPC_S04(this));
        m_AllState[(int)StaticGlobalDel.EMovableState.eDeath].AllThisState.Add(new CDeathStateNPC_S04(this));

        // ================= Buff ===========================
        m_AllCreateList[(int)CMovableBuffPototype.EMovableBuff.eSurpris] = () => { return new CSurprisBuffBase(this); };
        m_AllCreateList[(int)CMovableBuffPototype.EMovableBuff.eScared] = () => { return new CScaredBuff(this); };
        // ============ Skill ==================
        //m_MyPlayerMemoryShare.m_AllSkill.ListAllSkill.Add(new CPlayerChargeSkill(this));
    }

    protected override void CreateMemoryShare()
    {
        if (m_MyMemoryShare == null)
            m_MyMemoryShare = m_MyActorMemoryShare = m_MyNPCMemoryShare = new CNPCStage004MemoryShare();

        if (m_MyMemoryShare.m_MyMovable == null)
            m_MyNPCMemoryShare.m_MyMovable = m_MyNPCMemoryShare.m_MyActor = m_MyNPCMemoryShare.m_MyNPCStage004 = this;


        base.CreateMemoryShare();
    }

    protected override void Start()
    {
        base.Start();

        SetChangState(CMovableStatePototype.EMovableState.eWait);
    }
}
