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
    protected bool m_RotationLoop = true;

    public CJumpInsertStatePlayer(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {
        m_BuffDoTweenID = StaticGlobalDel.GetDoTweenID();
        


        m_MyPlayerMemoryShare.m_MyRigidbody.useGravity = true;
        m_MyPlayerMemoryShare.m_MyRigidbody.isKinematic = false;
         m_MyPlayerMemoryShare.m_MyRigidbody.velocity = m_MyPlayerMemoryShare.m_AddForce;

        m_HasHit = false;

        Vector3 lTempStartToEndDir = m_MyPlayerMemoryShare.m_EndPos - m_MyPlayerMemoryShare.m_StartePos.position;
        lTempStartToEndDir.Normalize();

        float lTempAngle = 360.0f - Vector3.SignedAngle(m_MyPlayerMemoryShare.m_MyTransform.forward, lTempStartToEndDir, m_MyPlayerMemoryShare.m_MyTransform.right) + Random.Range(5.0f, 10.0f);

        m_MyPlayerMemoryShare.m_MyRigidbody.DORotate(new Vector3(-lTempAngle, 0.0f, 0.0f), 0.7f, RotateMode.LocalAxisAdd);
    }

    protected override void FixedupdataState()
    {
        if (!m_HasHit)
        {
            m_HasHit = Physics.Raycast(new Ray(m_MyPlayerMemoryShare.m_MyTransform.position, m_MyPlayerMemoryShare.m_MyTransform.forward), out m_RaycastHitInfo, 0.4f, ~StaticGlobalDel.g_PlayerMask);

            if (m_HasHit)
            {
                Debug.Log(m_RaycastHitInfo.collider.name);

                UseGravityRigidbody(false);
                m_MyPlayerMemoryShare.m_MyTransform.parent = m_RaycastHitInfo.transform.parent.parent;

                if (m_RaycastHitInfo.collider.gameObject.layer == (int)StaticGlobalDel.ELayerIndex.eFloor)
                {
                    ChangState(EMovableState.eDeath);
                    return;
                }

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

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == (int)StaticGlobalDel.ELayerIndex.eFloor)
        {
            if (m_StateTime < 0.1f)
                return;

            ChangState(EMovableState.eDeath);
        }

        if (m_StateTime > 0.1f)
            m_RotationLoop = false;
    }

    public override void OnTriggerStay(Collider other)
    {
        CChangeDirTag lTempCChangeDirTag = other.gameObject.GetComponent<CChangeDirTag>();

        if (lTempCChangeDirTag == null)
            return;

        m_MyPlayerMemoryShare.m_MyRigidbody.velocity += lTempCChangeDirTag.Force;
    }
}
