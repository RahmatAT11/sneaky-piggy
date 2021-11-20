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
        [SerializeField] private Text timeText;
        [SerializeField] private float timeRemaining = 15f;
        private bool _timeIsRunning;
        private IWinnable _victoryManager;

        private void Start()
        {
            _timeIsRunning = true;
            _victoryManager = FindObjectOfType<VictoryManager>();
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
                    Debug.Log("Time has run out!");
                    timeRemaining = 0;
                    _timeIsRunning = false;
                    _victoryManager.SetIsTimeRunningOut(!_timeIsRunning);
                }
            }
        }

        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
