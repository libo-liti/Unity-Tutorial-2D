using System;
using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageble
{
    public float hp;
    public abstract void SetHealth();
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0f)
            Death();
    }

    public void Death()
    {
        Debug.Log("Death");
    }
}
