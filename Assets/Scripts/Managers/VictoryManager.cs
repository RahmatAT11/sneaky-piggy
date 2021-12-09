using System.Collections;
using UnityEngine;
using Interfaces;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Controllers;

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
        private bool _isAllTreasureCollected;

        [SerializeField] private GameObject panelWin, panelLose, star1, star2, star3, controllerUI, cameraController;
        [SerializeField] private Image detectedInfoFill;
        [SerializeField] private GameObject particlePrefabs, playerObj;
        private Transform playerPos;

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

            Time.timeScale = 1f;

            detectedInfoFill.fillAmount = 1;

            playerPos = GameObject.Find("Player(Clone)").GetComponent<Transform>();
            playerObj = GameObject.Find("Player(Clone)");
        }

        private void Update()
        {
            GameWin();

            if (_isPlayerDetected)
            {
                detectedInfoFill.fillAmount = 0;
            }
        }     
        
        public void GameWin()
        {
            if (_isCatchByNpc)
            {
                StartCoroutine(WaitingForWinLosePanelShow(2, "lose"));
                return;
            }

            if (_isTimeRunningOut)
            {
                StartCoroutine(WaitingForWinLosePanelShow(2, "lose"));
                return;
            }

            if (_isMainTreasureGet && _isPlayerEscape)
            {
                StartCoroutine(WaitingForWinLosePanelShow(2, "win"));

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

        private IEnumerator WaitingForWinLosePanelShow(float time, string winlose)
        {
            switch (winlose)
            {
                case "win":
                    controllerUI.SetActive(false);
                    cameraController.GetComponent<CameraController>().enabled = false;

                    yield return new WaitForSecondsRealtime(time);

                    panelWin.SetActive(true);

                    break;

                case "lose":
                    controllerUI.SetActive(false);
                    GameObject.Instantiate(particlePrefabs, playerPos.position, Quaternion.identity);
                    playerObj.SetActive(false);

                    yield return new WaitForSecondsRealtime(1);
                    particlePrefabs.SetActive(false);

                    yield return new WaitForSecondsRealtime(time);

                    panelLose.SetActive(true);
                    break;
            } 
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
