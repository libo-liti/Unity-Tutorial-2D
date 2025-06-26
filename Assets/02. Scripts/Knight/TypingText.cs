using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TypingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private float typingSpeed = 0.1f;

    
    private string _currText;

    private void Awake()
    {
        _currText = textUI.text;
    }

    private void OnEnable()
    {
        textUI.text = string.Empty;

        StartCoroutine(TypingRoutine());
    }

    private IEnumerator TypingRoutine()
    {
        int textCount = _currText.Length;
        for (int i = 0; i < textCount; i++)
        {
            textUI.text += _currText[i];
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
