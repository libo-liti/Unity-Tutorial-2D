using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemEvent : MonoBehaviour
{
    public enum ColliderType {Pipe, Apple, Both}
    public ColliderType colliderType;

    public GameObject pipe;
    public GameObject apple;
    public GameObject particle;
    
    public float pipeSpeed;
    public float returnPosX = 11f;
    public float randomPosY;
    
    public GameObject fadeUI;

    private void Start()
    {
        SetRandomSetting(transform.position.x);
    }

    void Update()
    {
        transform.position += pipeSpeed * Time.fixedDeltaTime * Vector3.left;

        if (transform.position.x <= -returnPosX)
            SetRandomSetting(returnPosX);
    }

    private void SetRandomSetting(float posX)
    {
        randomPosY = Random.Range(-8, -4);
        transform.position = new Vector3(posX, randomPosY, 0);

        colliderType = (ColliderType)Random.Range(0, 3);
        
        pipe.SetActive(false);
        apple.SetActive(false);
        particle.SetActive(false);
        
        switch (colliderType)
        {
            case ColliderType.Pipe:
                pipe.SetActive(true);
                break;
            case ColliderType.Apple:
                apple.SetActive(true);
                break;
            case ColliderType.Both:
                pipe.SetActive(true);
                apple.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    
    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         fadeUI.SetActive(true);
    //     }
    // }
}
