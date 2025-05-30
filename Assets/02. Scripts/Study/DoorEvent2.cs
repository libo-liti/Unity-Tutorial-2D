using System;
using UnityEngine;

public class DoorEvent2 : MonoBehaviour
{
    private Animator _animator;
    public string openKey;
    public string closeKey;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            _animator.SetTrigger(openKey);
            
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            _animator.SetTrigger(closeKey);
    }
}
