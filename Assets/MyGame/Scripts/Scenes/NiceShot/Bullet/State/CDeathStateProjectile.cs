using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDeathStateProjectile : CBulletS05StateBase
{
    public override EMovableState StateType() { return EMovableState.eDeath; }


    public CDeathStateProjectile(CMovableBase pamMovableBase) : base(pamMovableBase)
    {

    }

    protected override void InState()
    {
        UseTirgger(false);
        UseGravityRigidbody(true);

        Vector3 lTempExplosionpos = m_MyBulletMemoryShare.m_MyBullet.ShowRenderer.transform.position + (m_MyBulletMemoryShare.m_MyTransform.forward * 0.1f);

        if (m_MyMemoryShare.m_MyAllCollider != null)
        {
          
            foreach (Collider hit in m_MyMemoryShare.m_MyAllCollider)
            {
                Rigidbody rb = hit.GetComponentInParent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(10.0f, lTempExplosionpos, 20.0f, 200.0F);
            }
        }



    }

    protected override void updataState()
    {


        base.updataState();
    }

    protected override void OutState()
    {

    }

    public override void OnTriggerEnter(Collider other)
    {

    }
}
