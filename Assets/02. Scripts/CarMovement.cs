using System;
using Unity.VisualScripting;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D carRb;
    private float h;
    void Start()
    {
        
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        carRb.linearVelocityX = h * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Enter");
    }

    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Stay");
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Exit");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Trigger Stay");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit");
    }
}
