using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBulletCam : MonoBehaviour
{
    [SerializeField] protected CinemachineSmoothPath    m_MyPath = null;
    [SerializeField] protected CinemachineVirtualCamera m_MyVirtualCamera = null;
    [SerializeField] protected CinemachineDollyCart     m_MyCinemachineDollyCart = null;

    public void SetLookTarget(Transform Look)
    {
        m_MyVirtualCamera.LookAt = Look;
    }
}
