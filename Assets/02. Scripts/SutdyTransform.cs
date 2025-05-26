using UnityEngine;

public class SutdyTransform : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 70f;
    void Start()
    {
        
    }
    void Update()
    {
        //transform.position += moveSpeed * Time.deltaTime * Vector3.forward;
        
        //transform.localPosition += moveSpeed * Time.deltaTime * Vector3.forward;
        
        //transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
        

        float angle = transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime;
        float localX = transform.eulerAngles.x;
        float localZ = transform.eulerAngles.z;
        
        //transform.rotation = Quaternion.Euler(localX, angle, localZ);
        
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        
        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
        
        transform.LookAt(Vector3.zero);
    }
}
