using System;
using UnityEngine;

public class DoorEvent2 : MonoBehaviour
{
    public GameObject doorLock;
    private Animator _animator;
    public string closeKey;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLock.SetActive(true);
        }        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLock.SetActive(false);
            if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Door Side Open"))
                _animator.SetTrigger(closeKey);
        }        
    }
}
