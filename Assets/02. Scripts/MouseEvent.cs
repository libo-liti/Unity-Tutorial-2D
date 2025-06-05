using System;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    private void Update()
    {
        
    }
    
    private void MouseClickEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Button Down");
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Button Down");
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Button Down");
        }
    }
}
