using UnityEngine;
using Controllers.Joystick;
using Controllers.Base;
using DragonBones;
using Interfaces.Player;
using State;

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
        public UnityArmatureComponent PlayerArmature
        {
            get
            {
                return unityArmatureComponent;
            }
        }
        
        // Player Component
        private IInputProcess _playerInput;
        private State.State _currentState;

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
            SetState(new IdleState(this));
        }

        private void Update()
        {
            MovementDirection = _playerInput.MovementInput(_joystick);
            _currentState.Tick();
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
            }
        }

        protected override void Turning()
        {
            bool lastSpriteFlipStatus = unityArmatureComponent._armature.flipX;
            if (MovementDirection.x < 0)
            {
                unityArmatureComponent._armature.flipX = true;
            }
            else if (MovementDirection.x > 0)
            {
                unityArmatureComponent._armature.flipX = false;
            }
            else
            {
                unityArmatureComponent._armature.flipX = lastSpriteFlipStatus;
            }
        }

        public void SetState(State.State state)
        {
            _currentState?.OnStateExit();

            _currentState = state;

            _currentState?.OnStateEnter();
        }

        public Vector3 GetMovementDirection()
        {
            return MovementDirection;
        }
    }
}
