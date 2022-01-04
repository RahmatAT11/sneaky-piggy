using System.Collections;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Controllers.Camera;
using Controllers.Treasure;
using DG.Tweening;

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

        [SerializeField] private GameObject star1, star2, star3, controllerUI, cameraController;
        [SerializeField] private Image detectedInfoFill;
        [SerializeField] private GameObject particlePrefabs, playerObj;
        [SerializeField] private DotweenUIManager DOTweenManager;
        [SerializeField] private CanvasGroup panelWin, panelLose;

        private Transform playerPos;
        private bool hasSoundPlayed = false;
        public int nextSceneLoad = 2;
        public int starCount;

        private void Start()
        {
            _isPlayerEscape = false;
            _isMainTreasureGet = false;
            _isTimeRunningOut = false;
            _isCatchByNpc = false;
            _isAllTreasureCollected = false;
            _isPlayerDetected = false;
            _isOnTime = true;

            panelWin.gameObject.SetActive(false);
            panelLose.gameObject.SetActive(false);
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);

            //Time.timeScale = 1f;

            detectedInfoFill.fillAmount = 1;

            playerObj = GameObject.FindWithTag("Player");
            playerPos = playerObj.transform;

            TreasureCollectorController.AllTreasureCollected += SetIsTreasureAllCollectedHandler;
            DOTweenManager = GetComponent<DotweenUIManager>();

            //level
            nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

            starCount = 0;
        }

        private void OnDestroy()
        {
            TreasureCollectorController.AllTreasureCollected -= SetIsTreasureAllCollectedHandler;
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
                    starCount = 3;
                    break;
                case "2B":
                    star1.SetActive(true);
                    star2.SetActive(true);
                    starCount = 2;
                    break;
                case "1B":
                    star1.SetActive(true);
                    starCount = 1;
                    break;
                case "0B":
                    star1.SetActive(false);
                    star2.SetActive(false);
                    star3.SetActive(false);
                    starCount = 0;
                    break;
            }
          
            if (starCount > GetStarStatus(SceneManager.GetActiveScene().name))
            {
                SetStarStatus(SceneManager.GetActiveScene().name, starCount);
            }
        }

        private IEnumerator WaitingForWinLosePanelShow(float time, string winlose)
        {
            
            switch (winlose)
            {
                case "win":

                    if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                    {
                        PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                    }

                    controllerUI.SetActive(false);
                    cameraController.GetComponent<CameraController>().enabled = false;

                    yield return new WaitForSecondsRealtime(time);

                    panelWin.gameObject.SetActive(true);

                    //DZ
                    
                    if (!hasSoundPlayed)
                    {
                        hasSoundPlayed = true;
                        SoundManager.Instance.PlayBGM("BGM Win");
                    }            

                    break;

                case "lose":
                    controllerUI.SetActive(false);
                    GameObject.Instantiate(particlePrefabs, playerPos.position, Quaternion.identity);
                    playerObj.SetActive(false);

                    yield return new WaitForSecondsRealtime(1);
                    particlePrefabs.SetActive(false);

                    yield return new WaitForSecondsRealtime(time);

                    panelLose.gameObject.SetActive(true);

                    //DZ
                    if (!hasSoundPlayed)
                    {
                        hasSoundPlayed = true;
                        SoundManager.Instance.PlayBGM("BGM Lose");
                    }

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

        private void SetIsTreasureAllCollectedHandler()
        {
            SetIsTreasureAllCollected(true);
        }

        public void SetIsPlayerDetected(bool isPlayerDetected)
        {
            _isPlayerDetected = isPlayerDetected;
        }

        public void SetIsOnTime(bool isOnTime)
        {
            _isOnTime = isOnTime;
        }


        public void SetStarStatus(string level, int status)
        {
            PlayerPrefs.SetInt("Level" + level, status);
        }

        public int GetStarStatus(string level)
        {
            return PlayerPrefs.GetInt("Level" + level);
        }
    }
}
