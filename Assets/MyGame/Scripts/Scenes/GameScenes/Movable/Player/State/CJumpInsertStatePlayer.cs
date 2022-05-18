using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CJumpInsertStatePlayer : CPlayerStateBase
{
    public override EMovableState StateType() { return EMovableState.eJump; }
    protected Tween m_RotateTween = null;
    protected int m_BuffDoTweenID = 0;
    protected bool m_HasHit = false;
    protected RaycastHit m_RaycastHitInfo;
    protected Vector3 m_RotateLocalAxis = Vector3.zero;

    public CJumpInsertStatePlayer(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {
        m_BuffDoTweenID = StaticGlobalDel.GetDoTweenID();
        
        m_RotateLocalAxis = Vector3.Cross(-m_MyPlayerMemoryShare.m_MyTransform.forward, Vector3.up);
        m_RotateLocalAxis.Normalize();

        m_MyPlayerMemoryShare.m_MyRigidbody.useGravity = true;
        m_MyPlayerMemoryShare.m_MyRigidbody.isKinematic = false;
         m_MyPlayerMemoryShare.m_MyRigidbody.velocity = m_MyPlayerMemoryShare.m_AddForce;

        m_HasHit = false;


    }

    protected override void FixedupdataState()
    {

      

        if (!m_HasHit)
        {
            m_HasHit = Physics.Raycast(m_MyPlayerMemoryShare.m_MyTransform.position, m_MyPlayerMemoryShare.m_MyTransform.forward, out m_RaycastHitInfo, 0.4f);
            m_MyPlayerMemoryShare.m_MyRigidbody.rotation = Quaternion.AngleAxis(Time.fixedDeltaTime * -210.0f, m_RotateLocalAxis) * m_MyPlayerMemoryShare.m_MyRigidbody.rotation;

            if (m_HasHit)
            {
                UseGravityRigidbody(false);
                m_MyPlayerMemoryShare.m_MyTransform.parent = m_RaycastHitInfo.transform.parent.parent;

                if (m_RaycastHitInfo.collider.gameObject.tag == StaticGlobalDel.TagWin)
                    ChangState(EMovableState.eWin);
            }
        }
    }

    //public void RaycastTest()
    //{
    //    m_HasHit = Physics.Raycast(m_MyPlayerMemoryShare.m_MyTransform.position, m_MyPlayerMemoryShare.m_MyTransform.forward, out m_RaycastHitInfo, 0.3f);
    //}

    protected override void OutState()
    {
       // DOTween.s
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void OnTriggerStay(Collider other)
    {
        CChangeDirTag lTempCChangeDirTag = other.gameObject.GetComponent<CChangeDirTag>();

        if (lTempCChangeDirTag == null)
            return;

        m_MyPlayerMemoryShare.m_MyRigidbody.velocity += lTempCChangeDirTag.Force;
    }
}
