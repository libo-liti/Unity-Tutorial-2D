using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float pipeSpeed;
    public float returnPosX = 11f;
    public float randomPosY;

    public GameObject fadeUI;
    void Update()
    {
        transform.position += pipeSpeed * Time.fixedDeltaTime * Vector3.left;

        if (transform.position.x <= -returnPosX)
        {
            randomPosY = Random.Range(-8, -4);
            transform.position = new Vector3(returnPosX, randomPosY, 0);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fadeUI.SetActive(true);
        }
    }
}
