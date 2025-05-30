using System;
using Unity.VisualScripting;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            animator.SetTrigger("Open");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            animator.SetTrigger("Close");
    }
}
