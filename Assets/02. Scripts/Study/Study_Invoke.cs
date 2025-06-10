using System;
using UnityEngine;

public class Study_Invoke : MonoBehaviour
{
    public float timer = 5f;
    public int count = 10;
    private void Start()
    {
        // Invoke("Bomb", timer);
        InvokeRepeating("Bomb", 0f, 1f);
    }

    private void Bomb()
    {
        Debug.Log($"현재 남은 시간 : {count}");
        count--;

        if(count == 0)
            Debug.Log("폭탄이 터졌습니다.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("Bomb");
            Debug.Log("폭탄이 해제 되었습니다.");
        }
    }
}
