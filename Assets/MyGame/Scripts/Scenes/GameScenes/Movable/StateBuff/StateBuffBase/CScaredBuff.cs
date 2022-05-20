using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CScaredBuff : CExpressionBuff
{
    public override EMovableBuff BuffType() { return EMovableBuff.eScared; }

    public CScaredBuff(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    public override void ShowFX()
    {
        CGGameSceneData lTempGameSceneData = CGGameSceneData.SharedInstance;
        m_ExpressionObj = StaticGlobalDel.NewFxAddParentShow(m_ShowPos, CGGameSceneData.EAllFXType.eScared);

    }

}
