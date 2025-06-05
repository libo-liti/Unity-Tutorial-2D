using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    public int count = 0;
    void Start()
    {
        while (count < 10)
        {
            count++;
            Debug.Log($"현재 {count}입니다");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
