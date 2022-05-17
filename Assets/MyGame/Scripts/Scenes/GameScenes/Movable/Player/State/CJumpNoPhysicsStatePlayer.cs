using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CJumpNoPhysicsStatePlayer : CJumpStatePlayer
{
    public override EMovableState StateType() { return EMovableState.eJump; }
    
    protected List<Vector3> m_BezierPath = new List<Vector3>();
    protected int m_BuffDoTweenID = 0;

    public CJumpNoPhysicsStatePlayer(CMovableBase pamMovableBase) : base(pamMovableBase)
    {


    }

    protected override void InState()
    {
        m_BuffDoTweenID = StaticGlobalDel.GetDoTweenID();
        SetPathMove();
    }

    protected override void updataState()
    {
        base.updataState();
    }

    protected override void OutState()
    {

    }

    public void SetPathMove()
    {
        DOTween.Kill(m_BuffDoTweenID);

        Vector3 StartePos = m_MyPlayerMemoryShare.m_MyTransform.position;
        Vector3 EndPos = m_MyPlayerMemoryShare.m_CurDataJumpBounce.NextBounceTransform.position;
        Vector3 CentralHighPos = ((StartePos + EndPos) * 0.5f) + (Vector3.up * 1.0f);

        m_BezierPath.Clear();
        const int CPathMaxCount = 20;
        for (int i = 0; i < CPathMaxCount; i++)
        {
            var t = (float)i / (float)CPathMaxCount;
            m_BezierPath.Add(StaticGlobalDel.GetBezierPoint(t, StartePos, CentralHighPos, EndPos));
        }
        m_BezierPath[m_BezierPath.Count - 1] = EndPos;

        Vector3[] lTempArrVector3 = m_BezierPath.ToArray();
        m_MyPlayerMemoryShare.m_MyTransform.DOPath(lTempArrVector3, 0.8f).SetEase(Ease.Linear).SetId(m_BuffDoTweenID);
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == StaticGlobalDel.TagWin)
            ChangState(EMovableState.eWin);
        else if (other.tag == StaticGlobalDel.TagJumpBounce)
        {
            CDataJumpBounce lTempDataJumpBounce = other.gameObject.GetComponent<CDataJumpBounce>();
            if (lTempDataJumpBounce != null)
            {
                m_MyPlayerMemoryShare.m_CurDataJumpBounce = lTempDataJumpBounce;
                SetPathMove();
            }
        }
    }
}
