using System;
using UnityEngine;
using UnityEngine.UI;
using Controllers.Joystick;
using Interfaces;

namespace Controllers
{
    public class PlayerController : BaseCharController
    {
        [Header("Treasure Magnetic")] private GameObject _treasureMagnetic;
        private Text _treasureInfo;
        private int _treasureNumber;

        [Header("Collected UI")] public Image filledCollectedUI;
        private float _treasureCount;
        private GameObject _treasure;

        private void Start()
        {
            _treasureInfo = GameObject.Find("Treasure Info").GetComponent<Text>();
            filledCollectedUI = GameObject.Find("CollectedFill").GetComponent<Image>();
            _treasure = GameObject.Find("Treasures");

            _treasureNumber = 0;
            _treasureCount = _treasure.transform.childCount;
            filledCollectedUI.fillAmount = 0;
        }

        private GameJoystickController _joystick;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            _joystick = FindObjectOfType<GameJoystickController>();
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

        void TreasureMagneticPick()
        {
            _treasureInfo.text = _treasureNumber.ToString();
            filledCollectedUI.fillAmount = _treasureNumber * (1 / _treasureCount);
        }

        public void AddTreasureNumber(int number)
        {
            _treasureNumber += number;
        }
    }
}
