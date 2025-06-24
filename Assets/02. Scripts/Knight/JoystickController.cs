using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private KnightContollerJoyStick KnightContollerJoyStick;
    [SerializeField] private GameObject backgroundUI;
    [SerializeField] private GameObject handlerUI;

    private Vector2 _startPos, _currPos;

    private void Start()
    {
        backgroundUI.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        backgroundUI.SetActive(true);
        backgroundUI.transform.position = eventData.position;
        _startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _currPos = eventData.position;
        Vector2 dragDir = _currPos - _startPos;

        float maxDist = Mathf.Min(dragDir.magnitude, 100f);
        handlerUI.transform.position = _startPos + dragDir.normalized * maxDist;
        
        KnightContollerJoyStick.InputJoystick(dragDir.x, dragDir.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        KnightContollerJoyStick.InputJoystick(0, 0);
        handlerUI.transform.localPosition = Vector2.zero;
        backgroundUI.SetActive(false);
    }
}
