using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWinStateNPC_S04 : CNPCS04StateBase
{
    public override EMovableState StateType() { return EMovableState.eWin; }

    public CWinStateNPC_S04(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {

        DataAddBuffInfo lTempDataAddBuffInfo = new DataAddBuffInfo();
        lTempDataAddBuffInfo.m_ListDataIndex.Add((int)CGGameSceneData.EAllFXType.eHappy);
        m_MyNPCMemoryShare.m_MyNPCStage004.AddBuff(CMovableBuffPototype.EMovableBuff.eExpression, lTempDataAddBuffInfo);


    }

    protected override void updataState()
    {
        base.updataState();
    }

    protected override void OutState()
    {

    }
}
