using System.Collections;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Controllers.Camera;
using Controllers.Treasure;
using Controllers.House;
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

        [SerializeField] private GameObject star1, star2, star3, controllerUI, cameraController, IndicatorMainTresuare, IndicatorExit, Roof;
        [SerializeField] private Image detectedInfoFill;
        [SerializeField] private GameObject particlePrefabs, playerObj, worldBorders;
        [SerializeField] private DotweenUIManager DOTweenManager;
        [SerializeField] private CanvasGroup panelWin, panelLose, kilau;
        [SerializeField] private RectTransform borderWin, borderLose;

        private Transform playerPos;
        private bool hasSoundPlayed = false;
        private bool isHasNotLose = false;
        public int nextSceneLoad = 2;
        public int starCount;

        [SerializeField] private Vector3 finalPos, originalPos, currentPos;

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
            kilau.gameObject.SetActive(false);
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);

            worldBorders.SetActive(true);

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
                
                StartCoroutine(WaitingForWinLosePanelShow(1f, "lose"));
                return;
            }

            if (_isTimeRunningOut)
            {
                StartCoroutine(WaitingForWinLosePanelShow(1f, "lose"));
                return;
            }

            if (_isMainTreasureGet && _isPlayerEscape)
            {
                StartCoroutine(WaitingForWinLosePanelShow(1.5f, "win"));

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

                    //CoinManager.Instance.coinValue = 30;
                    //PlayerPrefs.SetInt("Coin", CoinManager.Instance.coinValue);

                    break;
                case "2B":
                    star1.SetActive(true);
                    star2.SetActive(true);
                    starCount = 2;

                    //CoinManager.Instance.coinValue = 20;
                    //PlayerPrefs.SetInt("Coin", CoinManager.Instance.coinValue);

                    break;
                case "1B":
                    star1.SetActive(true);
                    starCount = 1;

                    //CoinManager.Instance.coinValue = 10;
                    //PlayerPrefs.SetInt("Coin", CoinManager.Instance.coinValue);

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

                    worldBorders.SetActive(false);
                    if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                    {
                        PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                    }

                    controllerUI.SetActive(false);
                    cameraController.GetComponent<CameraController>().enabled = false;

                    yield return new WaitForSecondsRealtime(time);

                    if (!hasSoundPlayed)
                    {
                        hasSoundPlayed = true;
                        SoundManager.Instance.PlayBGM("BGM Win");

                        borderWin.DOAnchorPos(new Vector2(0, 9.5f), 0.8f);

                        panelWin.gameObject.SetActive(true);
                        panelWin.alpha = 0f;
                        panelWin.DOFade(1f, 0.5f).SetUpdate(true);

                        yield return new WaitForSecondsRealtime(0.45f);

                        kilau.gameObject.SetActive(true);
                        kilau.alpha = 0f;
                        kilau.DOFade(1f, 0.2f).SetUpdate(true);
                    }
                    break;

                case "lose":
                    controllerUI.SetActive(false);
                    Roof.SetActive(false);
                    if(!isHasNotLose)
                    {
                        isHasNotLose = true;
                        SoundManager.Instance.PlaySFX("SFX Random");
                        GameObject.Instantiate(particlePrefabs, playerPos.position, Quaternion.identity);
                        playerObj.SetActive(false);
                    }
                    

                    yield return new WaitForSecondsRealtime(1);
                    //particlePrefabs.SetActive(false);

                    yield return new WaitForSecondsRealtime(time);

                    //panelLose.gameObject.SetActive(true);

                    if (!hasSoundPlayed)
                    {
                        hasSoundPlayed = true;
                        SoundManager.Instance.PlayBGM("BGM Lose");

                        borderLose.DOAnchorPos(new Vector2(0, 9.5f), 0.8f);

                        panelLose.gameObject.SetActive(true);
                        panelLose.alpha = 0f;
                        panelLose.DOFade(1f, 0.5f).SetUpdate(true);
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

        public void IndicatorCondition()
        {
            if (_isMainTreasureGet == true)
            {
                IndicatorMainTresuare.GetComponent<Target>().enabled = false;
                IndicatorExit.GetComponent<Target>().enabled = true;
            }
            if (_isMainTreasureGet == false)
            {
                IndicatorMainTresuare.GetComponent<Target>().enabled = true;
                IndicatorExit.GetComponent<Target>().enabled = false;
            }
        }
    }
}
