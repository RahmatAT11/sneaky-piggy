using UnityEngine;

namespace Controllers.Treasure
{
    public class TreasureCollectorController : MonoBehaviour
    {
        // Treasure Data
        private float _treasureNumber;
        public float TreasureNumber
        {
            get
            {
                return _treasureNumber;
            }
        }
        
        private float _treasureCount;
        public float TreasureCount
        {
            get
            {
                return _treasureCount;
            }
        }
        
        private bool _isCollectedAllTreasures;
        public bool IsCollectedAllTreasures
        {
            get
            {
                return _isCollectedAllTreasures;
            }

            set
            {
                _isCollectedAllTreasures = value;
            }
        }
        
        private GameObject _treasure;

        public delegate void AllTreasureCollectedHandler();
        public static event AllTreasureCollectedHandler AllTreasureCollected;
        
        private void Awake()
        {
            _treasure = GameObject.Find("Treasures");
        }

        private void Start()
        {
            _treasureNumber = 0;
            _treasureCount = _treasure.transform.childCount;

            TreasureController.TreasureCollected += AddTreasureNumberHandler;
            TreasureController.TreasureCollected += ChangeAllTreasureCollectedStatusHandler;
        }

        private void OnDestroy()
        {
            TreasureController.TreasureCollected -= AddTreasureNumberHandler;
            TreasureController.TreasureCollected -= ChangeAllTreasureCollectedStatusHandler;
        }

        // akan di eksekusi ketika player berhasil menyentuh
        // treasure (berhasil mengambil)
        public void AddTreasureNumber(int number)
        {
            _treasureNumber += number;
        }

        public void AddTreasureNumberHandler()
        {
            AddTreasureNumber(1);
        }

        private void ChangeAllTreasureCollectedStatus()
        {
            if (Mathf.FloorToInt(_treasureNumber) == Mathf.FloorToInt(_treasureCount))
            {
                AllTreasureCollected?.Invoke();
            }
        }

        private void ChangeAllTreasureCollectedStatusHandler()
        {
            ChangeAllTreasureCollectedStatus();
        }
    }
}