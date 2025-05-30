using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Movement.coinCount++;
            Debug.Log($"현재까지 {Movement.coinCount}개 획득!!");
            
            Destroy(gameObject);
        }
            
    }
}
