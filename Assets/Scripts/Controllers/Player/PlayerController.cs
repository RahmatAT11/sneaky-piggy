using UnityEngine;
using Controllers.Joystick;
using Controllers.Base;
using DragonBones;
using Interfaces.Player;

namespace Controllers.Player
{
    public class PlayerController : BaseCharController
    {
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
            _playerInput = GetComponent<PlayerInput>();
            
            _staminaSystem = FindObjectOfType<StaminaSystemController>();
        }
        private void Start()
        {
            //MovementSpeed = 0.5f;
            //_sprintSpeedMultiplier = 5f;
            _staminaSystem.Amount = staminaUseAmount;
            unityArmatureComponent.animation.Play("Idle");
        }

        private void OnEnable()
        {
            unityArmatureComponent.animation.Play("Idle");
        }

        private void Update()
        {
            MovementDirection = _playerInput.MovementInput(_joystick);
            if (MovementDirection.magnitude == 0f)
            {
                unityArmatureComponent.animation.Play("Idle");
                IsWalking = false;
            }
            else
            {
                IsWalking = true;
            }
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
                unityArmatureComponent.animation.Play("Run");
            }
        }

        protected override void Walking()
        {
            if (IsWalking)
            {
                base.Walking();
                unityArmatureComponent.animation.Play("Walk");
            }
        }

        protected override void Turning()
        {
            unityArmatureComponent._armature.flipX = MovementDirection.x < 0;
        }
    }
}
