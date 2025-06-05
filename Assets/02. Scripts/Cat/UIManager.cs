using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public GameObject playObj;
        public GameObject introUI;
        
        public TMP_InputField inputfield;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
        }

        public void OnStartButton()
        {
            bool isNoText = inputfield.text == "";
            
            if (isNoText)
            {
                Debug.Log("입력된 텍스트 없음");
            }
            else
            {
                playObj.SetActive(true);
                introUI.SetActive(false);
                
                nameTextUI.text = inputfield.text;
            }
        }
    }
}

