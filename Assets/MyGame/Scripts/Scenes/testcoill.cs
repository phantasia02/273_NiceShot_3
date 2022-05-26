using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcoill : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter 11111111111111");
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter 11111111111111");
    }
}
