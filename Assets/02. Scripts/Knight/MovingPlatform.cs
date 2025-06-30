using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum  MoveType {Horizontal, Vertical}
    public MoveType moveType;
    
    public float theta = 0.1f;
    public float power = 1f;
    public float speed = 1f;

    private Vector3 _initPos;

    private void Start()
    {
        _initPos = transform.position;
    }

    private void Update()
    {
        theta += Time.deltaTime * speed;
        if(moveType == MoveType.Horizontal)
            transform.position = new Vector3(_initPos.x + power * Mathf.Sin(theta), _initPos.y, _initPos.z);
        else if(moveType == MoveType.Vertical)
            transform.position = new Vector3(_initPos.x,_initPos.y + power * Mathf.Sin(theta), _initPos.z);

    }
}
