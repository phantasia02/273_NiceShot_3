using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CNPCBaseMemoryShare : CActorMemoryShare
{
    public CNPCBase m_MyNPCBase = null;

};

public class CNPCBase : CActor
{
    public override EActorType MyActorType() { return EActorType.eNPC; }
    protected CNPCBaseMemoryShare m_MyNPCMemoryShare = null;


    protected override void AddInitState()
    {

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            m_AllState[(int)StaticGlobalDel.EMovableState.eWait].AllThisState.Add(new CWaitStateNPC_S04(this));
            m_AllState[(int)StaticGlobalDel.EMovableState.eDeath].AllThisState.Add(new CDeathStateNPC_S04(this));
            m_AllState[(int)StaticGlobalDel.EMovableState.eWin].AllThisState.Add(new CWinStateNPC_S04(this));
        }
        else
        {
            m_AllState[(int)StaticGlobalDel.EMovableState.eWait].AllThisState.Add(new CWaitStateBase(this));
        }

        AddBuff();
    }

    public void AddBuff()
    {
        // ================= Buff ===========================
        m_AllCreateList[(int)CMovableBuffPototype.EMovableBuff.eSurpris] = () => { return new CSurprisBuffBase(this); };
        m_AllCreateList[(int)CMovableBuffPototype.EMovableBuff.eExpression] = () => { return new CExpressionBuff(this); };
        // ============ Skill ==================
        //m_MyPlayerMemoryShare.m_AllSkill.ListAllSkill.Add(new CPlayerChargeSkill(this));
    }

    protected override void CreateMemoryShare()
    {
        if (m_MyMemoryShare == null)
            m_MyMemoryShare = m_MyActorMemoryShare = m_MyNPCMemoryShare = new CNPCBaseMemoryShare();

        if (m_MyMemoryShare.m_MyMovable == null)
            m_MyNPCMemoryShare.m_MyMovable = m_MyNPCMemoryShare.m_MyActor = m_MyNPCMemoryShare.m_MyNPCBase = this;


        base.CreateMemoryShare();
    }

    protected override void Start()
    {
        base.Start();

        SetChangState(CMovableStatePototype.EMovableState.eWait);
    }
}