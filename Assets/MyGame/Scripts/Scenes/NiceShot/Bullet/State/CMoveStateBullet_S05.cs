using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CMoveStateBullet_S05 : CBulletS05StateBase
{
    public override EMovableState StateType() { return EMovableState.eMove; }
    Transform m_CamObj = null;
    protected bool m_HasHit = false;
    protected RaycastHit m_RaycastHitInfo;

    public CMoveStateBullet_S05(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {
        if (m_MyBulletMemoryShare.m_MyBullet.MyTargetNpc != null)
        {
            //Debug.Log($"m_MyBulletMemoryShare.m_MyBullet.MyTargetNpc = {m_MyBulletMemoryShare.m_MyBullet.MyTargetNpc != null}");

            m_CamObj = StaticGlobalDel.NewOtherObjAddParentShow(m_MyBulletMemoryShare.m_MyTransform, CGGameSceneData.EOtherObj.eBulletCam);
            m_CamObj.transform.rotation = m_MyBulletMemoryShare.m_MyTransform.rotation;

            Time.timeScale = 0.1f;
        }

    }

    protected override void updataState()
    {
        m_MyBulletMemoryShare.m_MyTransform.Translate(m_MyBulletMemoryShare.m_MyTransform.forward * Time.deltaTime * m_MyBulletMemoryShare.m_TotleSpeed.Value, Space.World);
        m_HasHit = Physics.Raycast(new Ray(m_MyBulletMemoryShare.m_MyTransform.position, m_MyBulletMemoryShare.m_MyTransform.forward), out m_RaycastHitInfo, 0.4f, ~StaticGlobalDel.g_PlayerMask);

        base.updataState();
    }

    protected override void OutState()
    {
        m_MyBulletMemoryShare.m_MyBullet.ShowRenderer.SetActive(false);


        Time.timeScale = 1.0f;
    }


    public override void OnTriggerEnter(Collider other)
    {
        ChangState(CMovableStatePototype.EMovableState.eWait);

        CNPCBase lTempNPCBase = other.gameObject.GetComponentInParent<CNPCBase>();
        if (lTempNPCBase != null)
            lTempNPCBase.SetChangState(EMovableState.eDeath);
        else
            m_MyGameManager.SetState(CGameManager.EState.eGameOver);


    }

    public override void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1111111111111111111");
    }

}
