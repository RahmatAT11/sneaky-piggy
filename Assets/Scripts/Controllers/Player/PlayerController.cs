using UnityEngine;
using UnityEngine.UI;
using Controllers.Joystick;
using Interfaces;
using Managers;
using DragonBones;

namespace Controllers.Player
{
    public class PlayerController : BaseCharController
    {
        private IWinnable _victoryManager;

        // Treasure Data
        private float _treasureNumber;
        private float _treasureCount;
        private bool _isCollectedAllTreasures;
        private GameObject _treasure;
        
        // Treasure UI
        private Image _filledCollectedUI;
        private Text _treasureInfo;

        // Joystick
        private GameJoystickController _joystick;
        private StaminaSystemController _staminaSystem;
        
        // Player Stamina
        [Header("Stamina")] 
        [SerializeField] private int staminaUseAmount = 1;
        [SerializeField] private UnityArmatureComponent unityArmatureComponent;
        
        // Player Component
        private IInputProcess _playerInput;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            _joystick = FindObjectOfType<GameJoystickController>();
            _victoryManager = FindObjectOfType<VictoryManager>();
            _playerInput = GetComponent<PlayerInput>();
            
            _staminaSystem = FindObjectOfType<StaminaSystemController>();
            
            _treasureInfo = GameObject.Find("Treasure Info").GetComponent<Text>();
            _filledCollectedUI = GameObject.Find("CollectedFill").GetComponent<Image>();
            _treasure = GameObject.Find("Treasures");
        }
        private void Start()
        {
            _treasureNumber = 0;
            _treasureCount = _treasure.transform.childCount;
            _filledCollectedUI.fillAmount = 0;
            
            //MovementSpeed = 0.5f;
            //_sprintSpeedMultiplier = 5f;
            _staminaSystem.Amount = staminaUseAmount;
            unityArmatureComponent.animation.Play("Walk");
        }

        private void Update()
        {
            MovementDirection = _playerInput.MovementInput(_joystick);
            TreasureMagneticPick();
        }

        private void FixedUpdate()
        {
            Walking();
            Turning();
            Sprinting();
        }

        protected override void Sprinting()
        {
            if (IsSprinting)
            {
                base.Sprinting();
                _staminaSystem.UseStamina(_staminaSystem.Amount);
                unityArmatureComponent.animation.timeScale = 1.5f;
            }
            else
            {
                unityArmatureComponent.animation.timeScale = 1f;
            }
        }

        protected override void Turning()
        {
            unityArmatureComponent._armature.flipX = MovementDirection.x < 0;
        }

        private void TreasureMagneticPick()
        {
            _treasureInfo.text = $"{_treasureNumber}";
            _filledCollectedUI.fillAmount = _treasureNumber * (1 / _treasureCount);

            if (Mathf.FloorToInt(_treasureCount) == Mathf.FloorToInt(_treasureNumber))
            {
                _isCollectedAllTreasures = true;
            }
            
            _victoryManager.SetIsTreasureAllCollected(_isCollectedAllTreasures);
        }

        public void AddTreasureNumber(int number)
        {
            _treasureNumber += number;
        }
    }
}
