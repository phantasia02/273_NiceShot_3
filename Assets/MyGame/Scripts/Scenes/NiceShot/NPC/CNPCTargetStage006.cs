using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNPCTargetStage006 : CNPCBase
{
    public override EActorType MyActorType() { return EActorType.eTarget; }

    // ==================== SerializeField ===========================================

    [SerializeField] protected List<Transform> m_AllRefPos = null;
    public List<Transform> AllRefPos => m_AllRefPos;

    [SerializeField] protected Transform m_NextPos = null;
    public Transform NextPos => m_NextPos;

    protected Transform m_TargetPos = null;
    public Transform TargetPos
    {
        set => m_TargetPos = value;
        get => m_TargetPos;
    }

    // ==================== SerializeField ===========================================
    protected override void AddInitState()
    {
        m_AllState[(int)StaticGlobalDel.EMovableState.eWait].AllThisState.Add(new CWaitStateNPC_S06(this));
        m_AllState[(int)StaticGlobalDel.EMovableState.eWait].AllThisState.Add(new CWaitStateBase(this));
        m_AllState[(int)StaticGlobalDel.EMovableState.eJump].AllThisState.Add(new CJumpStateNPC_S06(this));
        m_AllState[(int)StaticGlobalDel.EMovableState.eJumpDown].AllThisState.Add(new CJumpDownStateNPC_S06(this));

        m_AllState[(int)StaticGlobalDel.EMovableState.eDeath].AllThisState.Add(new CDeathStateNPC_Target(this));

        AddBuff();
    }

    protected override void Start()
    {
        base.Start();

        SetChangState(CMovableStatePototype.EMovableState.eJump);
    }
}
