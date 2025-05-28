using System;
using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Enter");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
    }
}
