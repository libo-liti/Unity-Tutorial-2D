using UnityEngine;

public class Study_Overloading : MonoBehaviour
{
    void Start()
    {
        Attack();
        Attack(true);
        Attack(10f);
        Attack(10, new GameObject("몬스터"));
    }

    public void Attack()
    {
        Debug.Log("공격");
    }

    public void Attack(bool isMagic)
    {
        if (isMagic)
            Debug.Log("마법 공격");
    }

    public void Attack(float damage)
    {
        Debug.Log($"{damage} 데미지 만큼 공격");
    }

    public void Attack(float damage, GameObject target)
    {
        Debug.Log($"{target.name}에게 {damage} 데미지 만큼 공격");
    }
}
