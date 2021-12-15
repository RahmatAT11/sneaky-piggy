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
        }

        private void Update()
        {
            UpdateTreasureCollectedUI();
            ChangeIfAllTreasureCollected();
        }

        private void UpdateTreasureCollectedUI()
        {
            treasureInfo.text = $"{_treasureCollector.TreasureNumber}";
            filledCollectedUI.fillAmount = 
                _treasureCollector.TreasureNumber * (1 / _treasureCollector.TreasureCount);
        }
        
        private void ChangeIfAllTreasureCollected()
        {
            if (Mathf.FloorToInt(_treasureCollector.TreasureNumber) == Mathf.FloorToInt(_treasureCollector.TreasureCount))
            {
                _treasureCollector.UpdateIsTreasureCollected(true);
            }
        }
    }
}
