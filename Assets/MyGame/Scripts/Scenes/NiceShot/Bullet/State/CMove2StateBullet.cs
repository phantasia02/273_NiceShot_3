using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CMove2StateBullet : CMoveStateBullet_S05
{
    public override EMovableState StateType() { return EMovableState.eMove; }

    CNPCBase m_TouchNpc = null;


    public CMove2StateBullet(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {
        m_TouchNpc = null;
        base.InState();
    }


    protected override void Touch(RaycastHit HitInfo)
    {
        Time.timeScale = 1.0f;

        if (m_TouchNpc == null)
        {
            m_TouchNpc = HitInfo.collider.gameObject.GetComponentInParent<CNPCBase>();
            if (m_TouchNpc != null)
            {
                m_AddTouchDis = 0.2f;
                m_TouchNpc.AllColliderEnabled(false);
                m_TouchNpc.SetChangState(EMovableState.eWait, 1);
                m_TouchNpc.transform.SetParent(m_MyBulletMemoryShare.m_MyTransform);
            }
            else
            { 
                ChangState(CMovableStatePototype.EMovableState.eWait);
                m_MyGameManager.SetState(CGameManager.EState.eGameOver);
            }
        }
        else
        {
            CBulletStage005 lTempMovableBase = HitInfo.collider.gameObject.GetComponentInParent<CBulletStage005>();
            if (lTempMovableBase != m_MyBulletMemoryShare.m_MyBullet)
            {
                ChangState(CMovableStatePototype.EMovableState.eWait);
                m_MyGameManager.SetState(CGameManager.EState.eWinUI);
            }
        }
    }
}
