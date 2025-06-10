using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager soundManager;
        
        public GameObject playObj;
        public GameObject introUI;
        public GameObject playUI;
        
        public TMP_InputField inputfield;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;


        private void Awake()
        {
            playObj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

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
                playUI.SetActive(true);
                GameManager.isPlay = true;
                soundManager.SetBGMSound("Play");
                
                nameTextUI.text = inputfield.text;
            }
        }
    }
}

