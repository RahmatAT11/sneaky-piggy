using System.Collections;
using UnityEngine;
using Interfaces;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class VictoryManager : MonoBehaviour, IWinnable
    {
        private bool _isPlayerEscape;
        private bool _isMainTreasureGet;
        private bool _isTimeRunningOut;
        private bool _isCatchByNpc;
        private bool _isPlayerDetected;
        private bool _isOnTime;

        [SerializeField] private bool _isAllTreasureCollected;

        [SerializeField] private Text victoryText;
        [SerializeField] private GameObject panelWin, panelLose, star1, star2, star3;
        private Color _colorLose = Color.red;
        private Color _colorWin = Color.green;

        private void Start()
        {
            _isPlayerEscape = false;
            _isMainTreasureGet = false;
            _isTimeRunningOut = false;
            _isCatchByNpc = false;
            _isAllTreasureCollected = false;
            _isPlayerDetected = false;
            _isOnTime = true;

            panelWin.SetActive(false);
            panelLose.SetActive(false);
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
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
                panelLose.SetActive(true);
                
                victoryText.gameObject.SetActive(true);
                victoryText.text = "You Lose";
                victoryText.color = _colorLose;
                StartCoroutine(WaitingForRestartGame(5));
                return;
            }

            if (_isTimeRunningOut)
            {
                panelLose.SetActive(true);

                victoryText.gameObject.SetActive(true);
                victoryText.text = "You Lose";
                victoryText.color = _colorLose;
                StartCoroutine(WaitingForRestartGame(5));
                return;
            }

            if (_isMainTreasureGet && _isPlayerEscape)
            {
                victoryText.gameObject.SetActive(true);
                victoryText.text = "You Win";
                victoryText.color = _colorWin;
                StartCoroutine(WaitingForRestartGame(5));

                if(_isOnTime && _isAllTreasureCollected && !_isPlayerDetected)
                {
                    SetStar("3B");
                }

                if ((_isOnTime && _isAllTreasureCollected && _isPlayerDetected) ||
                    (_isOnTime && !_isAllTreasureCollected && !_isPlayerDetected) ||
                    (!_isOnTime && _isAllTreasureCollected && !_isPlayerDetected))
                {
                    SetStar("2B");
                }

                if ((!_isOnTime && !_isAllTreasureCollected && !_isPlayerDetected) ||
                    (!_isOnTime && _isAllTreasureCollected && _isPlayerDetected) ||
                    (_isOnTime && !_isAllTreasureCollected && _isPlayerDetected))
                {
                    SetStar("1B");
                }

                if (!_isOnTime && !_isAllTreasureCollected && _isPlayerDetected)
                {
                    SetStar("0B");
                }

            }
        }

        private void SetStar(string star)
        {
            panelWin.SetActive(true);

            switch (star)
            {
                case "3B":
                    star1.SetActive(true);
                    star2.SetActive(true);
                    star3.SetActive(true);
                    break;
                case "2B":
                    star1.SetActive(true);
                    star2.SetActive(true);
                    break;
                case "1B":
                    star1.SetActive(true);
                    break;
                case "0B":
                    star1.SetActive(false);
                    star2.SetActive(false);
                    star3.SetActive(false);
                    break;
            }
        }

        private IEnumerator WaitingForRestartGame(float time)
        {
            Time.timeScale = 0f;
            yield return new WaitForSecondsRealtime(time);
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

        public void SetIsTreasureAllCollected(bool isAllTreasureCollected)
        {
            _isAllTreasureCollected = isAllTreasureCollected;
        }

        public void SetIsPlayerDetected(bool isPlayerDetected)
        {
            _isPlayerDetected = isPlayerDetected;
        }

        public void SetIsOnTime(bool isOnTime)
        {
            _isOnTime = isOnTime;
        }
    }
}
