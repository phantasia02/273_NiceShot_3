using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CWaitStatePlayer : CPlayerStateBase
{
    public override EMovableState StateType() { return EMovableState.eWait; }

    public CWaitStatePlayer(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {

        StaticGlobalDel.ObjListChangLayer(m_MyPlayerMemoryShare.m_PlayerListRenderObj, StaticGlobalDel.ELayerIndex.eRenderFlashModelShow);
    }

    protected override void updataState()
    {
        if (m_MyPlayerMemoryShare.m_MyPlayer.RayInputTest())
        {
            m_MyPlayerMemoryShare.m_MyPlayer.SaveMouseDown();
            ChangState(EMovableState.eDrag);
        }

        base.updataState();
    }

    protected override void OutState()
    {
        StaticGlobalDel.ObjListChangLayer(m_MyPlayerMemoryShare.m_PlayerListRenderObj, StaticGlobalDel.ELayerIndex.ePlayer);
    }

    //public override void MouseDown()
    //{
    //    ChangState(EMovableState.eDrag);
        
    //}

    //public override void MouseDrag()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(m_MyPlayerMemoryShare.m_CurMouseDownPos);

    //    //if (Physics.Raycast(ray, out RaycastHit hit, 128))
    //    //{
    //    //  //  Debug.Log(hit.collider.name);
    //    //    Debug.Log(hit.collider.gameObject.layer);
    //    //}


    //    RaycastHit[] lTempRaycastHit = Physics.RaycastAll(ray, 100.0f, StaticGlobalDel.g_PlayerMask);

    //  //  Debug.Log(" ==================== ");
    //    foreach (var item in lTempRaycastHit)
    //    {
    //        Debug.Log(item.collider.gameObject.layer);
    //        //  m_MyPlayerMemoryShare.m_EndPos = item.point;
    //        //  break;
    //    }
    //}

}
