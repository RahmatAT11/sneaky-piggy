using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using UnityEngine;
using Interfaces;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class VictoryManager : MonoBehaviour, IWinnable
    {
        private bool _isPlayerEscape;
        private bool _isMainTreasureGet;
        private bool _isTimeRunningOut;
        private bool _isCatchByNpc;

        private void Start()
        {
            _isPlayerEscape = false;
            _isMainTreasureGet = false;
            _isTimeRunningOut = false;
            _isCatchByNpc = false;
        }

        private void Update()
        {
            GameWin();
        }

        private void RestartGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }        
        
        public void GameWin()
        {
            if (_isCatchByNpc)
            {
                Debug.Log("Player was catch by NPC!");
                StartCoroutine(WaitingForRestartGame(5));
                return;
            }

            if (_isTimeRunningOut)
            {
                Debug.Log("Time is run out!");
                StartCoroutine(WaitingForRestartGame(5));
                return;
            }

            if (_isMainTreasureGet && _isPlayerEscape)
            {
                Debug.Log("You Win!");
                StartCoroutine(WaitingForRestartGame(5));
            }
        }

        private IEnumerator WaitingForRestartGame(float time)
        {
            Debug.Log("Start");
            Time.timeScale = 0f;
            yield return new WaitForSecondsRealtime(time);
            Debug.Log("Finish");
            RestartGame();
        }

        public void SetIsPlayerEscape(bool isPlayerEscape)
        {
            _isPlayerEscape = isPlayerEscape;
        }

        public void SetIsMainTreasureGet(bool isMainTreasureGet)
        {
            _isMainTreasureGet = isMainTreasureGet;
        }

        public void SetIsTimeRunningOut(bool isTimeRunningOut)
        {
            _isTimeRunningOut = isTimeRunningOut;
        }

        public void SetIsCatchByNpc(bool isCatchByNpc)
        {
            _isCatchByNpc = isCatchByNpc;
        }
    }
}
