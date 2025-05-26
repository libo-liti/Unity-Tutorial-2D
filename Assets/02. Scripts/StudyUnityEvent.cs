using System;
using UnityEngine;

public class StudyUnityEvent : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void Start()
    {
        Debug.Log("Start");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnalbe");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void Update()
    {
        
    }
}
