using System;
using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;
    public float smothValue;

    private Vector3 starPos;
    private float timer, percent, lerpTime;
    private void Start()
    {
        starPos = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        percent = timer / lerpTime;
        
        transform.position = Vector3.Lerp(starPos, targetPos, percent);
    }
}
