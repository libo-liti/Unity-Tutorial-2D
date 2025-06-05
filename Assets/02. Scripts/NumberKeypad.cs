using TMPro;
using UnityEngine;

public class NumberKeypad : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject doorLock;
    public Animator _animator;
    public string openKey;
    public string password;
    public string keyPadNumber;

    public void OnInputNumber(string numString)
    {
        keyPadNumber += numString;
        text.text = $"현재 입력 : {keyPadNumber}";
    }

    public void OnCheckNumber()
    {
        text.text = "현재 입력 : ";
        if (keyPadNumber == password)
        {
            doorLock.SetActive(false);
            _animator.SetTrigger(openKey);
        }
        keyPadNumber = "";
    }
}
