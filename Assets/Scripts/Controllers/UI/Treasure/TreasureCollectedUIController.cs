using System;
using Controllers.Treasure;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI.Treasure
{
    public class TreasureCollectedUIController : MonoBehaviour
    {
        // Treasure UI
        [SerializeField] private Image filledCollectedUI;
        [SerializeField] private Text treasureInfo;
        
        // Treasure Data
        private TreasureCollectorController _treasureCollector;

        private void Awake()
        {
            _treasureCollector = FindObjectOfType<TreasureCollectorController>();
        }

        private void Start()
        {
            filledCollectedUI.fillAmount = 0;

            TreasureController.TreasureCollected += UpdateTreasureCollectedUIHandler;
        }

        private void OnDestroy()
        {
            TreasureController.TreasureCollected -= UpdateTreasureCollectedUIHandler;
        }

        private void UpdateTreasureCollectedUIHandler()
        {
            UpdateTreasureCollectedUI();
        }

        private void Update()
        {
            UpdateTreasureCollectedUI();
        }

        private void UpdateTreasureCollectedUI()
        {
            treasureInfo.text = $"{_treasureCollector.TreasureNumber}";
            filledCollectedUI.fillAmount = 
                _treasureCollector.TreasureNumber * (1 / _treasureCollector.TreasureCount);
        }
    }
}
