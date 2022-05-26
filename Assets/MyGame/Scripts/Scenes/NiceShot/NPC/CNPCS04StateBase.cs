using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CNPCS04StateBase : CMovableStatePototype
{
    protected CNPCBaseMemoryShare m_MyNPCMemoryShare = null;

    public CNPCS04StateBase(CMovableBase pamMovableBase) : base(pamMovableBase)
    {
        m_MyNPCMemoryShare = (CNPCBaseMemoryShare)m_MyMemoryShare;
    }

    protected override void InState()
    {
    }

    protected override void updataState()
    {
    }
}
