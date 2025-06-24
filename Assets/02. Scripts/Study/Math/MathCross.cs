using System;
using UnityEngine;

public class MathCross : MonoBehaviour
{
    public Vector3 VecA = new Vector3(1, 0, 0);
    public Vector3 VecB = new Vector3(0, 1, 0);

    private void Start()
    {
        Vector3 result = Vector3.Cross(VecA, VecB);

        Debug.Log($"벡터의 외적 : {result}");

        Vector3 result2 = Vector3.Reflect(VecA, VecB);
    }
}
