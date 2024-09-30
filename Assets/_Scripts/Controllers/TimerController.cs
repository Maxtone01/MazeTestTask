using System;
using _Scripts.Managers;
using TMPro;
using UnityEngine;

namespace _Scripts.Controllers
{
    public class TimerController: MonoBehaviour
    {
        private string timerText;
        private float startTime;
        private bool startTimer;
        [SerializeField] private TextMeshProUGUI _timerText;

        private void Start()
        {
            EventManager.Instance.OnGameWin += EndGame;
            EventManager.Instance.OnPlayerCaptured += EndGame;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnGameWin -= EndGame;
            EventManager.Instance.OnPlayerCaptured -= EndGame;
        }

        public void StartTimer()
        {
            startTime = Time.time;
            startTimer = true;
        }

        private void Update()
        {
            if (startTimer)
            {
                UpdateTimerValue();
            }
        }

        private void UpdateTimerValue()
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            _timerText.text = minutes + ":" + seconds;
        }

        public void EndGame()
        {
            startTimer = false;
            Debug.Log("Час гри: " + timerText);
        }
    }
}