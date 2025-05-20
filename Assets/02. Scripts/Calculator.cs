using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int number1;
    public int number2;

    int AddMethod()
    {
        int result = number1 + number2;
        return result;
    }

    int MinusMethod()
    {
        int result = number1 - number2;
        return result;
    }
    
    void Start()
    {
        int addResult = AddMethod();
        int minusResult = MinusMethod();

        Debug.Log($"더한 값 : {addResult} / 뺀 값 : {minusResult}");
    }
    void Update()
    {
        
    }
}
