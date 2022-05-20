using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CNPCStage004MemoryShare : CMemoryShareBase
{
    public CNPCStage004 m_MyNPCStage004 = null;
   
};

public class CNPCStage004 : CMovableBase
{
    public override EMovableType MyMovableType() { return EMovableType.eNpc; }

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
            m_MyMemoryShare.m_MyMovable = m_MyNPCMemoryShare.m_MyNPCStage004 = this;



        base.CreateMemoryShare();

        // ================= Buff ===========================
        m_AllCreateList[(int)CMovableBuffPototype.EMovableBuff.eSurpris] = () => { return new CSurprisBuffBase(this); };
        m_AllCreateList[(int)CMovableBuffPototype.EMovableBuff.eScared] = () => { return new CScaredBuff(this); };
        m_AllCreateList[(int)CMovableBuffPototype.EMovableBuff.eWeep] = () => { return new CWeepBuff(this); };
        // ============ Skill ==================
        //m_MyPlayerMemoryShare.m_AllSkill.ListAllSkill.Add(new CPlayerChargeSkill(this));


    }

    protected override void Start()
    {
        base.Start();

        SetChangState(CMovableStatePototype.EMovableState.eWait);
    }
}
