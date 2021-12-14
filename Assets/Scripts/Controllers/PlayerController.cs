using UnityEngine;
using UnityEngine.UI;
using Controllers.Joystick;
using Interfaces;
using Managers;
using DragonBones;
using AnimationState = DragonBones.AnimationState;

namespace Controllers
{
    public class PlayerController : BaseCharController
    {
        private IWinnable _victoryManager;

        [Header("Treasure Magnetic")] 
        private GameObject _treasureMagnetic;
        private Text _treasureInfo;
        public float _treasureNumber;

        [Header("Collected UI")] 
        public Image filledCollectedUI;
        [SerializeField] public float _treasureCount;
        private GameObject _treasure;
        [SerializeField] private bool isCollectedAllTreasures;

        private GameJoystickController _joystick;
        private StaminaSystemController _staminaSystem;
        [Header("Stamina")] 
        [SerializeField] private int staminaUseAmount = 1;

        [SerializeField] private UnityArmatureComponent _animation;
        private AnimationState _currentAnimState;

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
            
            //MovementSpeed = 0.5f;
            //_sprintSpeedMultiplier = 5f;
            _staminaSystem.Amount = staminaUseAmount;
            _animation.animation.Play("Walk");
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
            if (IsSprinting)
            {
                base.Sprinting();
                _staminaSystem.UseStamina(_staminaSystem.Amount);
                _animation.animation.timeScale = 1.5f;
            }
            else
            {
                _animation.animation.timeScale = 1f;
            }
        }

        protected override void Turning()
        {
            if (MovementDirection.x < 0)
            {
                _animation._armature.flipX = true;
            }
            else
            {
                _animation._armature.flipX = false;
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
    }
}
