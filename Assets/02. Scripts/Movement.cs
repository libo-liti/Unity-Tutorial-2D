using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.back;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        }
    }
}
