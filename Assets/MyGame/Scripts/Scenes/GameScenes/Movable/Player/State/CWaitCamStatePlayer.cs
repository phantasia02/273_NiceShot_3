using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWaitCamStatePlayer : CPlayerStateBase
{
    public override EMovableState StateType() { return EMovableState.eWait; }

    public CWaitCamStatePlayer(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {
        m_MyPlayerMemoryShare.m_MyTransform.rotation = Camera.main.transform.rotation;
        m_MyPlayerMemoryShare.m_MyTransform.position = Camera.main.transform.position + (Camera.main.transform.forward * 1.5f);
  
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
}
