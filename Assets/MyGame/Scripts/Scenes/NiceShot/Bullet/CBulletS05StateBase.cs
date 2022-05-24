using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CBulletS05StateBase : CMovableStatePototype
{
    protected CBulletStage005MemoryShare m_MyBulletMemoryShare = null;

    public CBulletS05StateBase(CMovableBase pamMovableBase) : base(pamMovableBase)
    {
        m_MyBulletMemoryShare = (CBulletStage005MemoryShare)m_MyMemoryShare;
    }

    protected override void InState()
    {
    }

    protected override void updataState()
    {
    }
}
