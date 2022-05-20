using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CWinStatePlayer : CPlayerStateBase
{
    public override EMovableState StateType() { return EMovableState.eWin; }

    public CWinStatePlayer(CMovableBase pamMovableBase) : base(pamMovableBase)
    {
        
    }

    protected override void InState()
    {
        UseGravityRigidbody(false);
        m_MyPlayerMemoryShare.m_MyPlayer.AllColliderEnabled(false);

        //float lTempTime = 0.0f;
        //Tween lTempTween = DOTween.To(() => lTempTime, x => lTempTime = x, 1.0f, 0.5f);
        //lTempTween.SetEase( Ease.Linear);
        //lTempTween.OnUpdate(() => {
        //    Quaternion.Lerp();
        //});


        if (m_MyGameManager.WinPosition != null)
        {
            float lTempMovetime = Vector3.Distance(m_MyPlayerMemoryShare.m_MyTransform.position, m_MyGameManager.WinPosition.position) * 0.2f;

            m_MyPlayerMemoryShare.m_MyPlayer.transform.DORotateQuaternion(m_MyGameManager.WinPosition.rotation, lTempMovetime - 0.1f).SetEase(Ease.OutQuart);
            Tween lTempTween = m_MyPlayerMemoryShare.m_MyTransform.DOMove(m_MyGameManager.WinPosition.position, lTempMovetime).SetEase(Ease.OutQuart);
            lTempTween.OnComplete(() => { m_MyGameManager.SetState(CGameManager.EState.eWinUI); });
        }
        else
            m_MyGameManager.SetState(CGameManager.EState.eWinUI);
    }

    protected override void updataState()
    {
        base.updataState();
    }

    protected override void OutState()
    {

    }


}
