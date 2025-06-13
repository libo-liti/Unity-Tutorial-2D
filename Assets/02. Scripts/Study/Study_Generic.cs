using System;
using UnityEngine;

public class Study_Generic : MonoBehaviour
{
    private void Start()
    {
        Factory<Monster> factory = new Factory<Monster>();
    }
}
