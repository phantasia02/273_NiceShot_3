using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTargetObj : CGameObjBas, IGameObjOpenGravity
{
    public override EObjType ObjType(){ return EObjType.eTargetApple; }

    public void OpenGravity(bool open)
    {
        Rigidbody[] lTempAllRigidbody = this.GetComponentsInChildren<Rigidbody>();
        foreach (var item in lTempAllRigidbody)
        {
            item.useGravity = open;
            item.isKinematic = !open;
        }
    }
}
