using System;
using UnityEngine;
using UnityEngine.UI;
using Controllers.Joystick;
using Interfaces;
using Managers;

namespace Controllers
{
    public class PlayerController : BaseCharController
    {
        private IWinnable _victoryManager;

        [Header("Treasure Magnetic")] private GameObject _treasureMagnetic;
        private Text _treasureInfo;
        public float _treasureNumber;

        [Header("Collected UI")] public Image filledCollectedUI;
        [SerializeField] public float _treasureCount;
        private GameObject _treasure;
        [SerializeField] private bool isCollectedAllTreasures;

        private void Start()
        {
            _treasureInfo = GameObject.Find("Treasure Info").GetComponent<Text>();
            filledCollectedUI = GameObject.Find("CollectedFill").GetComponent<Image>();
            _treasure = GameObject.Find("Treasures");

            _treasureNumber = 0;
            _treasureCount = _treasure.transform.childCount;
            filledCollectedUI.fillAmount = 0;

            isCollectedAllTreasures = false;
        }

        private GameJoystickController _joystick;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            _joystick = FindObjectOfType<GameJoystickController>();
            _victoryManager = FindObjectOfType<VictoryManager>();
        }

        private void Update()
        {
            ProcessInput();
            TreasureMagneticPick();
        }

        private void ProcessInput()
        {
            /*float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");*/

            float xAxis = _joystick.InputHorizontal();
            float yAxis = _joystick.InputVertical();

            MovementDirection.Set(xAxis, yAxis, 0f);
        }

        private void FixedUpdate()
        {
            Walking();
            Turning();
            Sprinting();
        }

        private void TreasureMagneticPick()
        {
            _treasureInfo.text = _treasureNumber.ToString();
            filledCollectedUI.fillAmount = _treasureNumber * (1 / _treasureCount);

            if (_treasureCount == _treasureNumber)
            {
                Debug.Log("AllCollected");
                isCollectedAllTreasures = true;
            }

            if (isCollectedAllTreasures == true)
            {
                _victoryManager.SetIsTreasureAllCollected(true);
            }
        }

        public void AddTreasureNumber(int number)
        {
            _treasureNumber += number;
        }
    }
}
