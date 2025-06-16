using UnityEngine;

public class Door : MonoBehaviour, IDamageble
{
    public float hp = 100f;
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0f)
            Death();
    }

    public void Death()
    {
        Debug.Log("파괴");
    }
}