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
        public GameObject videoPanel;
        
        public TMP_InputField inputfield;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;
        public Button reStartButton;


        private void Awake()
        {
            playObj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
            reStartButton.onClick.AddListener(OnReStartButton);
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

        public void OnReStartButton()
        {
            playObj.SetActive(true);
            GameManager.ResetPlayUI();
            videoPanel.SetActive(false);
        }
    }
}

