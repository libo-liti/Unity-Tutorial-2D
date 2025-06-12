using System;
using TMPro;
using UnityEngine;

namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager soundManager;
        
        public TextMeshProUGUI scoreUI;
        public TextMeshProUGUI playTimeUI;
        
        private static float timer;
        public static int score;
        public static bool isPlay;

        private void Start()
        {
            soundManager.SetBGMSound("Intro");
        }

        void Update()
        {
            if (!isPlay)
                return;
            
            timer += Time.deltaTime;
            // playTimeUI.text = timer.ToString();
            playTimeUI.text = string.Format("플레이 시간 : {0:F1}초", timer);
            scoreUI.text = $"X {score}";
        }

        public static void ResetPlayUI()
        {
            timer = 0f;
            score = 0;
        }
    }
}

