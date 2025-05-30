using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public static int coinCount = 0;
    void Start()
    {
        
    }

    void Update()
    {
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        Vector3 nomalDir = dir.normalized;

        // Debug.Log($"현재 입력 : {dir}");
        
        transform.position += moveSpeed * Time.deltaTime * nomalDir;
        transform.LookAt(transform.position + nomalDir);
    }
}
