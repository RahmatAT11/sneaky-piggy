using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controllers.Joystick;
using Interfaces;
using Managers;
using UnityEngine.Events;

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

        private GameJoystickController _joystick;
        private StaminaSystemController _staminaSystem;
        
        // Just for sake of using character
        [SerializeField] private List<Sprite> pigs;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            _joystick = FindObjectOfType<GameJoystickController>();
            _victoryManager = FindObjectOfType<VictoryManager>();
            
            _staminaSystem = FindObjectOfType<StaminaSystemController>();
            _treasureInfo = GameObject.Find("Treasure Info").GetComponent<Text>();
            filledCollectedUI = GameObject.Find("CollectedFill").GetComponent<Image>();
            _treasure = GameObject.Find("Treasures");
        }
        private void Start()
        {
            _treasureNumber = 0;
            _treasureCount = _treasure.transform.childCount;
            filledCollectedUI.fillAmount = 0;

            isCollectedAllTreasures = false;
            MovementSpeed = 5f;
            _sprintSpeedMultiplier = 2f;
            _staminaSystem.Amount = 1;
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

        protected override void Sprinting()
        {
            if (isSprinting)
            {
                Rigidbody2D.velocity = MovementDirection * (MovementSpeed * _sprintSpeedMultiplier);
                _staminaSystem.UseStamina(_staminaSystem.Amount);
            }
        }

        private void TreasureMagneticPick()
        {
            _treasureInfo.text = _treasureNumber.ToString();
            filledCollectedUI.fillAmount = _treasureNumber * (1 / _treasureCount);

            if (_treasureCount == _treasureNumber)
            {
                isCollectedAllTreasures = true;
            }
            
            _victoryManager.SetIsTreasureAllCollected(isCollectedAllTreasures);
        }

        public void AddTreasureNumber(int number)
        {
            _treasureNumber += number;
        }

        private void SetPigSprite(int index)
        {
            GetComponent<SpriteRenderer>().sprite = pigs[index];
        }
    }
}
