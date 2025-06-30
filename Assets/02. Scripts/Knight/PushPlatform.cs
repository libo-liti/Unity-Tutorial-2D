using System;
using UnityEngine;

public class PushPlatform : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _targetRb;
    [SerializeField] private float pushPower = 19f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _targetRb = other.GetComponent<Rigidbody2D>();
            Invoke("PushCharacter", 1f);
        }
    }

    private void PushCharacter()
    {
        _targetRb.AddForceY(pushPower, ForceMode2D.Impulse);
        _animator.SetTrigger("Push");
    }
}
