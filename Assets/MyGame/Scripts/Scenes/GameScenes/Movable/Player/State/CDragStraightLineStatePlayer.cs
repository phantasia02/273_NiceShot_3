using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDragStraightLineStatePlayer : CPlayerStateBase
{
    public override EMovableState StateType() { return EMovableState.eDrag; }
    Vector3 m_BuffCameraForward = Vector3.zero;
    Vector3 m_BuffCameraRight = Vector3.zero;
    Vector3 m_StartPos = Vector3.zero;
    Quaternion m_DefCurVcamQ = Quaternion.identity;

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


        m_MyGameManager.OpenPhysics = false;
        m_DefCurVcamQ = m_MyGameManager.CurVcamObjAnima.rotation;
        //m_MyGameManager.CurVcamObjAnima.rotation.
        //Debug.Log($"m_MyGameManager.CurVcamObjAnima.rotation.x = {m_MyGameManager.CurVcamObjAnima.rotation.x}");
        //Debug.Log($"m_MyGameManager.CurVcamObjAnima.rotation.y = {m_MyGameManager.CurVcamObjAnima.rotation.y}");
        //Debug.Log($"m_MyGameManager.CurVcamObjAnima.rotation.z = {m_MyGameManager.CurVcamObjAnima.rotation.z}");

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

        lTempV3 = (m_BuffCameraRight * (lTempV3.x / Screen.width) * m_MyPlayerMemoryShare.m_CurStageData.AddForce.x) +
                    (Vector3.up * (lTempV3.y / Screen.height) * m_MyPlayerMemoryShare.m_CurStageData.AddForce.y);


        m_MyGameManager.CurVcamObjAnima.rotation = m_DefCurVcamQ * Quaternion.AngleAxis(-lTempV3.y, Vector3.right) * Quaternion.AngleAxis(-lTempV3.x, Vector3.up);

        m_MyPlayerMemoryShare.m_MyTransform.rotation = Camera.main.transform.rotation;
        m_MyPlayerMemoryShare.m_MyTransform.position = Camera.main.transform.position + (Camera.main.transform.forward * 1.5f);
    }


    public override void MouseUp()
    {
        Transform lTempBullet = StaticGlobalDel.NewFxAddParentShow(m_MyGameManager.gameObject.transform, CGGameSceneData.EAllFXType.eBullet);
        lTempBullet.position = m_MyPlayerMemoryShare.m_MyTransform.position;
        lTempBullet.forward = m_MyPlayerMemoryShare.m_MyTransform.forward;

        m_MyPlayerMemoryShare.m_MyPlayer.SetChangState(EMovableState.eWait, 1);
    }

}
