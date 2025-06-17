using System;
using UnityEngine;

public class Study_Property : MonoBehaviour
{
    private int number1 = 10;
    public int a;

    public int Number1
    {
        get { return number1; }
        set { number1 = value; }
    }
    
    
    
}


public class External : MonoBehaviour
{
    public Study_Property studyProperty;
    private int n = 1;

    public int N
    {
        get
        {
            return n;
        }
        set
        {
            n = value;
        }
        
    }

    private void Start()
    {
        int num1 = studyProperty.Number1;
        studyProperty.Number1 = 100;
    }
}