using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDragStraightLineStatePlayer : CPlayerStateBase
{
    public override EMovableState StateType() { return EMovableState.eDrag; }
    Vector3 m_BuffCameraForward = Vector3.zero;
    Vector3 m_BuffCameraRight = Vector3.zero;
    Vector3 m_StartPos = Vector3.zero;

    public CDragStraightLineStatePlayer(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {
        m_MyPlayerMemoryShare.m_MyPlayer.ObserverPlayStartEvent().OnNext(UniRx.Unit.Default);

        StaticGlobalDel.ObjListChangLayer(m_MyPlayerMemoryShare.m_TargetListRenderObj, StaticGlobalDel.ELayerIndex.eRenderFlashModelShow);

        m_BuffCameraForward = m_MyGameManager.MainCamera.gameObject.transform.forward;
        m_BuffCameraForward.y = 0.0f;
        m_BuffCameraForward.Normalize();

        m_BuffCameraRight = m_MyGameManager.MainCamera.gameObject.transform.right;
        m_BuffCameraRight.y = 0.0f;
        m_BuffCameraRight.Normalize();

        m_StartPos = m_MyPlayerMemoryShare.m_MyTransform.position;

        m_MyGameManager.OpenPhysics = false;
    }

    protected override void updataState()
    {
        base.updataState();
    }

    protected override void OutState()
    {
        StaticGlobalDel.ObjListChangLayer(m_MyPlayerMemoryShare.m_TargetListRenderObj, StaticGlobalDel.ELayerIndex.eDef);
    }

    public override void MouseDrag()
    {
        Vector3 lTempV3 = m_MyPlayerMemoryShare.m_CurMouseDownPos - m_MyPlayerMemoryShare.m_DownMouseDownPos;
       // Debug.Log($"m_MyPlayerMemoryShare.m_CurMouseDownPos = {m_MyPlayerMemoryShare.m_CurMouseDownPos}");
        lTempV3 = (m_BuffCameraRight * (lTempV3.x / Screen.width) * m_MyPlayerMemoryShare.m_CurStageData.AddForce.x) +
                    (Vector3.up * (lTempV3.y / Screen.height) * m_MyPlayerMemoryShare.m_CurStageData.AddForce.y);

        
        m_MyPlayerMemoryShare.m_MyTransform.position = m_MyPlayerMemoryShare.m_StartePos.position + lTempV3;
    }

}
