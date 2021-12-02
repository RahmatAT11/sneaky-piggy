using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class TimerManager : MonoBehaviour
    {
        [SerializeField] private Text timeText, onTimeFillText;
        [SerializeField] private float timeRemaining;
        [SerializeField] private float timeOnTime, timeOnTimeCounter;
        [SerializeField] private GameObject panicDisplay;
        [SerializeField] private Image onTimeFill;
        private float timeCounter;
        private bool _timeIsRunning, _onTimeIsRunning;
        private IWinnable _victoryManager;

        private void Start()
        {
            _timeIsRunning = true;
            _onTimeIsRunning = true;
            _victoryManager = FindObjectOfType<VictoryManager>();

            timeCounter = timeRemaining;
            timeOnTimeCounter = timeRemaining - timeOnTime;
            panicDisplay.SetActive(false);

            onTimeFill.fillAmount = 1;
        }

        private void Update()
        {
            if (_timeIsRunning)
            {
                DisplayTime(timeRemaining);
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    _victoryManager.SetIsTimeRunningOut(false);
                }
                else
                {
                    timeRemaining = 0;
                    _timeIsRunning = false;
                    _victoryManager.SetIsTimeRunningOut(!_timeIsRunning);
                }

                if (timeRemaining <= timeOnTime)
                {
                    _victoryManager.SetIsOnTime(false);
                    panicDisplay.SetActive(true);
                }

                DisplayOnTime();
            }
        }

        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private void DisplayOnTime()
        {
            if (_onTimeIsRunning)
            {
                onTimeFill.fillAmount -= 1 / timeOnTimeCounter * Time.deltaTime;
                timeOnTimeCounter -= Time.deltaTime;
                onTimeFillText.text = timeOnTimeCounter.ToString("0");
            }
            else
            {
                timeOnTimeCounter = 0;
            }

            if (timeOnTimeCounter <= 0)
            {
                _onTimeIsRunning = false;
                timeOnTimeCounter = 0;
            }
        }
    }
}
