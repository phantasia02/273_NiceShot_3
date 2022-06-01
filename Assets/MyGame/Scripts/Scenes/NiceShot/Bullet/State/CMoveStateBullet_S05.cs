using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CMoveStateBullet_S05 : CBulletS05StateBase
{
    public override EMovableState StateType() { return EMovableState.eMove; }
    Transform m_CamObj = null;
    protected bool m_LongHasHit = false;
    protected RaycastHit m_RaycastHitInfo;
    float m_LongHasHitDis = 1.0f;
    protected float m_AddTouchDis = 0.0f;


    public CMoveStateBullet_S05(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {

        m_CamObj = StaticGlobalDel.NewOtherObjAddParentShow(m_MyBulletMemoryShare.m_MyTransform, CGGameSceneData.EOtherObj.eBulletCam);
        m_CamObj.transform.rotation = m_MyBulletMemoryShare.m_MyTransform.rotation;

        //Time.timeScale = 0.5f;

        Tween lTempTween = m_MyBulletMemoryShare.m_MyBullet.ShowRenderer.transform.DORotate(new Vector3(0.0f, 0.0f, -360.0f), m_MyBulletMemoryShare.m_ProjectileData.RotateTime, RotateMode.LocalAxisAdd);
        lTempTween.SetLoops(-1);
        lTempTween.SetEase(Ease.Linear);
        lTempTween.SetId(m_MyBulletMemoryShare.m_MyBullet.ShowRenderer.transform);

        m_LongHasHitDis = m_MyBulletMemoryShare.m_TotleSpeed.Value / 5.0f;
    }

    protected override void FixedupdataState()
    {
        m_MyBulletMemoryShare.m_MyTransform.Translate(m_MyBulletMemoryShare.m_MyTransform.forward * Time.fixedDeltaTime * m_MyBulletMemoryShare.m_TotleSpeed.Value, Space.World);

        if (!m_LongHasHit)
        {
            if (Physics.Raycast(new Ray(m_MyBulletMemoryShare.m_MyTransform.position, m_MyBulletMemoryShare.m_MyTransform.forward), out RaycastHit TempLongHitInfo, m_LongHasHitDis))
            {
                m_LongHasHit = true;
                CNPCBase lTempNPCBase = TempLongHitInfo.collider.gameObject.GetComponentInParent<CNPCBase>();
                if (lTempNPCBase != null)
                {
                    Time.timeScale = 0.1f;
                    Time.fixedDeltaTime = StaticGlobalDel.fixedDeltaTime * Time.timeScale;

                    m_CamObj.transform.SetParent(m_MyGameManager.transform);
                }
            }
        }
        else
        {
            if (Physics.Raycast(new Ray(m_MyBulletMemoryShare.m_MyTransform.position, m_MyBulletMemoryShare.m_MyTransform.forward), out RaycastHit TempHitInfo, m_MyBulletMemoryShare.m_ProjectileData.TouchDis + m_AddTouchDis))
            {
                Touch(TempHitInfo);
            }
        }

        //Debug.DrawRay(m_MyBulletMemoryShare.m_MyTransform.position, m_MyBulletMemoryShare.m_MyTransform.forward * 0.3f, Color.red);

        base.updataState();
    }

    protected override void OutState()
    {
        DOTween.Kill(m_MyBulletMemoryShare.m_MyBullet.ShowRenderer.transform);
    }


    protected virtual void Touch(RaycastHit HitInfo)
    {
        ChangState(CMovableStatePototype.EMovableState.eWait);
        m_MyBulletMemoryShare.m_MyBullet.ShowRenderer.SetActive(false);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = StaticGlobalDel.fixedDeltaTime * Time.timeScale;

        CNPCBase lTempNPCBase = HitInfo.collider.gameObject.GetComponentInParent<CNPCBase>();
        if (lTempNPCBase != null)
            lTempNPCBase.SetChangState(EMovableState.eDeath);
        else
            m_MyGameManager.SetState(CGameManager.EState.eGameOver);
    }

    //public override void OnTriggerEnter(Collider other)
    //{
    //    ChangState(CMovableStatePototype.EMovableState.eWait);

    //    CNPCBase lTempNPCBase = other.gameObject.GetComponentInParent<CNPCBase>();
    //    if (lTempNPCBase != null)
    //        lTempNPCBase.SetChangState(EMovableState.eDeath);
    //    else
    //        m_MyGameManager.SetState(CGameManager.EState.eGameOver);


    //}
}
