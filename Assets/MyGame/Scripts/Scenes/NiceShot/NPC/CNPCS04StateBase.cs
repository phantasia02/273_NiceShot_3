using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CNPCS04StateBase : CMovableStatePototype
{
    protected CNPCStage004MemoryShare m_MyNPCMemoryShare = null;

    public CNPCS04StateBase(CMovableBase pamMovableBase) : base(pamMovableBase)
    {
        m_MyNPCMemoryShare = (CNPCStage004MemoryShare)m_MyMemoryShare;
    }

    protected override void InState()
    {
    }

    protected override void updataState()
    {
    }
}
