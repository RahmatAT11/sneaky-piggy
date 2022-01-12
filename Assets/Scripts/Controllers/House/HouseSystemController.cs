using System.Collections.Generic;
using UnityEngine;
using Managers;
using Interfaces;

namespace Controllers.House
{
    public class HouseSystemController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> mutableWalls;

        public delegate void PlayerEnter(bool isEnter);
        public static event PlayerEnter PlayerEntered;
        private bool isInOutdoor;
        [SerializeField] GameObject IndicatorMainTresuare, IndicatorExit;
        private IWinnable _victoryManager;

        private void Start()
        {
            PlayerEntered += ShowInsideHouse;
            _victoryManager = FindObjectOfType<VictoryManager>();
            isInOutdoor = true;
        }

        private void Update()
        {
            if (isInOutdoor == true)
            {
                IndicatorMainTresuare.GetComponent<Target>().enabled = false;
                IndicatorExit.GetComponent<Target>().enabled = false;
            }

            if (isInOutdoor == false)
            {
                _victoryManager.IndicatorCondition();
            }
        }

        private void OnDestroy()
        {
            PlayerEntered -= ShowInsideHouse;
        }

        private void ShowInsideHouse(bool isDoorOpen)
        {
            foreach (var wall in mutableWalls)
            {
                wall.GetComponent<SpriteRenderer>().enabled = !isDoorOpen;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerEntered?.Invoke(true);
                SoundManager.Instance.PlayBGM("BGM Dalam Rumah");
                isInOutdoor = false;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerEntered?.Invoke(false);
                SoundManager.Instance.PlayBGM("BGM Diluar Rumah");
                isInOutdoor = true;
            }
        }
    }
}
