using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CDragStraightLineStatePlayer : CPlayerStateBase
{
    public override EMovableState StateType() { return EMovableState.eDrag; }
    Vector3 m_BuffCameraForward = Vector3.zero;
    Vector3 m_BuffCameraRight = Vector3.zero;
    Vector3 m_StartPos = Vector3.zero;
    Quaternion m_DefCurVcamQ = Quaternion.identity;
    Vector3 m_OriginalAng = Vector3.zero;

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
        m_OriginalAng = m_MyGameManager.CurVcamObjAnima.eulerAngles;
        //m_MyGameManager.CurVcamObjAnima.rotation.
        //Debug.Log($"m_MyGameManager.CurVcamObjAnima.rotation.x = {m_MyGameManager.CurVcamObjAnima.rotation.x}");
        //Debug.Log($"m_MyGameManager.CurVcamObjAnima.rotation.y = {m_MyGameManager.CurVcamObjAnima.rotation.y}");
        //Debug.Log($"m_MyGameManager.CurVcamObjAnima.rotation.z = {m_MyGameManager.CurVcamObjAnima.rotation.z}");
        m_MyGameManager.OpenPhysics = false;
    }

    protected override void updataState()
    {
        base.updataState();
    }

    protected override void OutState()
    {
        StaticGlobalDel.ObjListChangLayer(m_MyPlayerMemoryShare.m_TargetListRenderObj, StaticGlobalDel.ELayerIndex.eDef);
        m_MyGameManager.OpenPhysics = true;
    }

    public override void MouseDrag()
    {
        Vector3 lTempV3 = m_MyPlayerMemoryShare.m_CurMouseDownPos - m_MyPlayerMemoryShare.m_OldMouseDownPos;

        lTempV3 = (m_BuffCameraRight * (lTempV3.x / Screen.width) * m_MyPlayerMemoryShare.m_CurStageData.AddForce.x) +
                    (Vector3.up * (lTempV3.y / Screen.height) * m_MyPlayerMemoryShare.m_CurStageData.AddForce.y);


        Vector3 lTempCurAngles = m_OriginalAng;
        lTempCurAngles.x -= lTempV3.y;
        lTempCurAngles.y -= lTempV3.x;


        //Debug.Log($"m_MyGameManager.CurVcamObjAnima.eulerAngles = {m_MyGameManager.CurVcamObjAnima.eulerAngles}");
         m_MyGameManager.CurVcamObjAnima.rotation = m_MyGameManager.CurVcamObjAnima.rotation * Quaternion.AngleAxis(-lTempV3.y, Vector3.right) * Quaternion.AngleAxis(-lTempV3.x, Vector3.up);

        m_MyPlayerMemoryShare.m_MyTransform.rotation = Camera.main.transform.rotation;
        m_MyPlayerMemoryShare.m_MyTransform.position = Camera.main.transform.position + (Camera.main.transform.forward * 1.5f);

        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        //Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red);
    }


    public override void MouseUp()
    {
        m_MyGameManager.SetAllActorTypeState(CActor.EActorType.eTarget, EMovableState.eWait, 1);
        m_MyPlayerMemoryShare.m_AllObj.gameObject.SetActive(false);

        GameObject lTempGameObject = m_MyGameManager.GetTimeObj(0);
        if (lTempGameObject != null)
            lTempGameObject.SetActive(false);

        Vector3 lTempHitPos = Vector3.zero;
        CNPCBase lTempTargetNPC = null; 
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));

        if (Physics.Raycast(ray, out RaycastHit info))
        {
            lTempTargetNPC = info.collider.gameObject.GetComponentInParent<CNPCBase>();
            lTempHitPos = info.point;
            //Debug.Log($"lTempTargetNPC = {lTempTargetNPC != null}");

            //if (lTempTargetNPC != null)
            //    Debug.Log($"  lTempTargetNPC.MyActorType(); = {  lTempTargetNPC.MyActorType()}");

        }
        m_MyPlayerMemoryShare.m_MyPlayer.SetChangState(EMovableState.eWait, 1);

        Transform lTempBullet = null;

        if (SceneManager.GetActiveScene().buildIndex == 5 )
            lTempBullet = StaticGlobalDel.NewFxAddParentShow(m_MyGameManager.gameObject.transform, CGGameSceneData.EAllFXType.eBullet);
        else if (SceneManager.GetActiveScene().buildIndex == 6)
            lTempBullet = StaticGlobalDel.NewFxAddParentShow(m_MyGameManager.gameObject.transform, CGGameSceneData.EAllFXType.eBulletDart);

        lTempBullet.position = m_MyPlayerMemoryShare.m_MyTransform.position;
        lTempBullet.forward = m_MyPlayerMemoryShare.m_MyTransform.forward;

        CBulletStage005 lTempCBulletStage005 = lTempBullet.GetComponentInChildren<CBulletStage005>();
        lTempCBulletStage005.MyTargetNpc = lTempTargetNPC;
        lTempCBulletStage005.HitPos = lTempHitPos;

        
    }

}
