using System;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyEvente : MonoBehaviour
{
    public float delayTime;
    void Start()
    {
        Destroy(this.gameObject, delayTime);
    }

    private void OnDestroy()
    {
        Debug.Log($"{gameObject.name}이 파괴되었습니다.");
    }
}
