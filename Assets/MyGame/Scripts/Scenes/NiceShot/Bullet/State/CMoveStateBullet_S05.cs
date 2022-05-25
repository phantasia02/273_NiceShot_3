using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CMoveStateBullet_S05 : CBulletS05StateBase
{
    public override EMovableState StateType() { return EMovableState.eMove; }
    Transform m_CamObj = null;

    public CMoveStateBullet_S05(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {
        m_CamObj = StaticGlobalDel.NewOtherObjAddParentShow(m_MyBulletMemoryShare.m_MyTransform, CGGameSceneData.EOtherObj.eBulletCam);
        m_CamObj.transform.rotation = m_MyBulletMemoryShare.m_MyTransform.rotation;

    }

    protected override void updataState()
    {
        m_MyBulletMemoryShare.m_MyTransform.Translate(m_MyBulletMemoryShare.m_MyTransform.forward * Time.deltaTime * 1.0f, Space.World);
        base.updataState();
    }

    protected override void OutState()
    {

    }
}
