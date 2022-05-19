using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CWeepBuff : CExpressionBuff
{
    public override EMovableBuff BuffType() { return EMovableBuff.eWeep; }

    public CWeepBuff(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    public override void ChageImage()
    {
        CGGameSceneData lTempGameSceneData = CGGameSceneData.SharedInstance;
        m_SpriteRenderer.sprite = lTempGameSceneData.m_AllExpressionSprite[(int)CGGameSceneData.EExpressionSpriteType.eWeep];
    }

    public override void DoTweenAnimation()
    {
        Vector3 lTempScale = m_ExpressionObj.localScale;
        m_ExpressionObj.localScale = Vector3.zero;
        m_ExpressionObj.DOScale(lTempScale, 0.5f);
    }
}
