using UnityEngine;

public class Transform_loopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float returnPosX = 11f;
    public float randomPosY;
    void Update()
    {
        transform.position += moveSpeed * Time.fixedDeltaTime * Vector3.left;

        if (transform.position.x <= -returnPosX)
        {
            randomPosY = Random.Range(-8f, -3f);
            transform.position = new Vector3(returnPosX, randomPosY, 0);
        }
    }
}
