using System;
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
        private bool _isGameOver;
        private bool _isGameWin;
        private List<NonPlayerController> _nPCs;

        private void Start()
        {
            _nPCs = FindObjectsOfType<NonPlayerController>().ToList();
        }

        public void GameWin()
        {
            if (_isGameOver)
            {
                if (_isGameWin)
                {
                    Debug.Log("You Win!");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                else
                {
                    Debug.Log("You Lose!");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }

        public void SetWin(bool isGameOver, bool isGameWin)
        {
            _isGameOver = isGameOver;
            _isGameWin = isGameWin;
        }

        public void SetWin(bool isGameWin)
        {
            _isGameWin = isGameWin;
        }

        private void Update()
        {
            GameWin();
        }
    }
}
