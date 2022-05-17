using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDataJumpBounce : MonoBehaviour
{
    // ==================== SerializeField ===========================================

    [SerializeField] protected Transform m_NextBounceTransform = null;
    public Transform NextBounceTransform => m_NextBounceTransform;
    [SerializeField] protected float m_PlayTime = 1.0f;
    public float PlayTime => m_PlayTime;
    [SerializeField] protected float m_JumpHigh = 1.0f;
    public float JumpHigh => m_JumpHigh;
    // ==================== SerializeField ===========================================



}
