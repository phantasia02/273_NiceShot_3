using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class CExpressionBuff : CMovableBuffPototype
{
    //protected Tween m_TweenAnimation = null;
    //protected SpriteRenderer m_SpriteRenderer = null;

    protected Transform m_ExpressionObj = null;
    protected Transform m_ShowPos = null;

    public override float BuffMaxTime() { return -1.0f; }

    public CExpressionBuff(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void AddBuff(DataAddBuffInfo data)
    {
        CSearchObjBase lTempFxPos = m_MyMovable.GetComponentInChildren<CSearchObjBase>();

        if (lTempFxPos == null)
        {
            Debug.LogError("lTempFxPos == null");
            m_MyMovable.RemoveBuff(this);
            return;
        }

        m_ShowPos = lTempFxPos.transform;
        ShowFX();

        //m_ExpressionObj = StaticGlobalDel.NewFxAddParentShow(lTempFxPos.transform, CGGameSceneData.EAllFXType.eExpression);
        //m_ExpressionObj.rotation = lTempFxPos.transform.rotation;
        //m_SpriteRenderer = m_ExpressionObj.GetComponent<SpriteRenderer>();

        //ChageImage();
        //DoTweenAnimation();
        //m_TweenAnimation = m_ExpressionObj.DOShakeRotation(1.0f, 10, 10, 90, false).SetLoops(-1).SetId(m_ExpressionObj);
    }

    abstract public void ShowFX();
    //abstract public void DoTweenAnimation();


    //protected override void updataState() { }

    //public override void LateUpdate() { }

    protected override void RemoveBuff()
    {
        //if (m_TweenAnimation != null)
        //    m_TweenAnimation.Kill();

        if (m_ExpressionObj != null)
            GameObject.Destroy(m_ExpressionObj);
    }
}
