using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CMoveStateRendRubberBand : CBulletS05StateBase
{
    public override EMovableState StateType() { return EMovableState.eMove; }

    Transform m_CamObj = null;
    protected bool m_LongHasHit = false;
    protected RaycastHit m_RaycastHitInfo;

    public CMoveStateRendRubberBand(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {
        m_CamObj = StaticGlobalDel.NewOtherObjAddParentShow(m_MyBulletMemoryShare.m_MyTransform, CGGameSceneData.EOtherObj.eBulletCam);
        m_CamObj.transform.rotation = m_MyBulletMemoryShare.m_MyTransform.rotation;


        Tween lTempTween = m_MyBulletMemoryShare.m_MyBullet.ShowRenderer.transform.DORotate(new Vector3(0.0f, 0.0f, -360.0f), 1f, RotateMode.LocalAxisAdd);
        lTempTween.SetLoops(-1);
        lTempTween.SetEase(Ease.Linear);
        lTempTween.SetId(m_MyBulletMemoryShare.m_MyBullet.ShowRenderer.transform);
        //}
    }

    protected override void updataState()
    {
        m_MyBulletMemoryShare.m_MyTransform.Translate(m_MyBulletMemoryShare.m_MyTransform.forward * Time.deltaTime * m_MyBulletMemoryShare.m_TotleSpeed.Value, Space.World);

        if (!m_LongHasHit)
        {
            if (Physics.Raycast(new Ray(m_MyBulletMemoryShare.m_MyTransform.position, m_MyBulletMemoryShare.m_MyTransform.forward), out RaycastHit TempLongHitInfo, 1.5f))
            {
                m_LongHasHit = true;
                CNPCBase lTempNPCBase = TempLongHitInfo.collider.gameObject.GetComponentInParent<CNPCBase>();
                if (lTempNPCBase != null)
                {
                    Time.timeScale = 0.1f;
                    m_CamObj.transform.SetParent(m_MyGameManager.transform);
                }
            }
        }

        base.updataState();
    }

    protected override void OutState()
    {
        DOTween.Kill(m_MyBulletMemoryShare.m_MyBullet.ShowRenderer.transform);
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
}
