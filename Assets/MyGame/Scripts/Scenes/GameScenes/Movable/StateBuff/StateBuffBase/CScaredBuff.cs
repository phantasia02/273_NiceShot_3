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

    public override void ChageImage()
    {
        CGGameSceneData lTempGameSceneData = CGGameSceneData.SharedInstance;
        m_SpriteRenderer.sprite = lTempGameSceneData.m_AllExpressionSprite[(int)CGGameSceneData.EExpressionSpriteType.eScared];
    }

    public override void DoTweenAnimation()
    {
        m_TweenAnimation = m_ExpressionObj.DOShakeRotation(1.0f, 10, 10, 90, false).SetLoops(-1).SetId(m_ExpressionObj);
    }

}
