using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBulletStage005MemoryShare : CMemoryShareBase
{
    public CBulletStage005 m_MyBullet = null;
};


public class CBulletStage005 : CMovableBase
{
    public override EMovableType MyMovableType() { return EMovableType.eBullet; }
    protected CBulletStage005MemoryShare m_MyBulletMemoryShare = null;

    public override float DefSpeed { get { return 10.0f; } }


    [SerializeField] protected GameObject m_ShowRenderer = null;
    public GameObject ShowRenderer => m_ShowRenderer;

    protected Vector3 m_HitPos = Vector3.zero;
    public Vector3 HitPos
    {
        get { return m_HitPos; }
        set { m_HitPos = value; }
    }

    protected CNPCBase m_MyTargetNpc = null;
    public CNPCBase MyTargetNpc
    {
        get { return m_MyTargetNpc; }
        set { m_MyTargetNpc = value; }
    }


    protected override void AddInitState()
    {
        m_AllState[(int)StaticGlobalDel.EMovableState.eMove].AllThisState.Add(new CMoveStateBullet_S05(this));
        m_AllState[(int)StaticGlobalDel.EMovableState.eWait].AllThisState.Add(new CWaitStateBase(this));

        // ================= Buff ===========================

        // ============ Skill ==================
        //m_MyPlayerMemoryShare.m_AllSkill.ListAllSkill.Add(new CPlayerChargeSkill(this));
    }

    protected override void CreateMemoryShare()
    {
        if (m_MyMemoryShare == null)
            m_MyMemoryShare  = m_MyBulletMemoryShare = new CBulletStage005MemoryShare();

        if (m_MyMemoryShare.m_MyMovable == null)
            m_MyBulletMemoryShare.m_MyMovable = m_MyBulletMemoryShare.m_MyBullet = this;

        base.CreateMemoryShare();
    }

    protected override void Start()
    {
        base.Start();
        SetChangState(CMovableStatePototype.EMovableState.eMove);
    }
}
