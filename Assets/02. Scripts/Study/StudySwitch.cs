using System;
using UnityEngine;

public class StudySwitch : MonoBehaviour
{
    public enum CalculationType {Plus = -1, Minus, Multiply, Divide}

    public CalculationType calculationType = CalculationType.Plus;

    public int input1, input2, result;

    private void Start()
    {
        Debug.Log($"계산 결과 : {Calculation()}");
    }

    int Calculation()
    {
        switch (calculationType)
        {
            case CalculationType.Plus :
                result = input1 + input2;
                break;
            case CalculationType.Minus :
                result = input1 - input2;
                break;
            case CalculationType.Multiply :
                result = input1 * input2;
                break;
            case CalculationType.Divide :
                result = input1 / input2;
                break;
        }
        return result;
    }
}
