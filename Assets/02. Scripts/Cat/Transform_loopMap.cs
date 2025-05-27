using UnityEngine;

public class Transform_loopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float height = 1.5f;
    public Vector3 returnPos;
    void Start()
    {
        returnPos = new Vector3(30f, height, 0f);
    }

    void Update()
    {
        transform.position += moveSpeed * Time.fixedDeltaTime * Vector3.left;

        if (transform.position.x <= -30f)
        {
            transform.position += Vector3.right * 60f;
        }
    }
}
