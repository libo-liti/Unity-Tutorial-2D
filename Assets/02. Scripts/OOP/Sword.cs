using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float damage = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDamageble>() != null)
            other.GetComponent<IDamageble>().TakeDamage(10f);
    }
}