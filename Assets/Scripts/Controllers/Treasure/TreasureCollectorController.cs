using Interfaces;
using Managers;
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

        private IWinnable _victoryManager;
        
        private GameObject _treasure;
        
        private void Awake()
        {
            _treasure = GameObject.Find("Treasures");
            _victoryManager = FindObjectOfType<VictoryManager>();
        }

        private void Start()
        {
            _treasureNumber = 0;
            _treasureCount = _treasure.transform.childCount;
        }

        // akan di eksekusi ketika player berhasil menyentuh
        // treasure (berhasil mengambil)
        public void AddTreasureNumber(int number)
        {
            _treasureNumber += number;
        }

        public void UpdateIsTreasureCollected(bool isCollectedAllTreasures)
        {
            _isCollectedAllTreasures = isCollectedAllTreasures;
            _victoryManager.SetIsTreasureAllCollected(_isCollectedAllTreasures);
        }
    }
}