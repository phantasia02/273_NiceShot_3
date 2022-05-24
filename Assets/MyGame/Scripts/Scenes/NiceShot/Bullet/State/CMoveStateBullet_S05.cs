using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveStateBullet_S05 : CBulletS05StateBase
{
    public override EMovableState StateType() { return EMovableState.eMove; }


    public CMoveStateBullet_S05(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {

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
