using UnityEngine;
using Controllers.Joystick;
using Controllers.Base;
using DragonBones;
using Interfaces.Player;
using State.Player;

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
        
        // Player Animation
        [Header("Animation")]
        [SerializeField] private BaseCharAnimationController animationController;
        public BaseCharAnimationController AnimationController
        {
            get
            {
                return animationController;
            }
        }
        
        // Player Component
        private IInputProcess _playerInput;
        private PlayerState _currentPlayerState;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            _joystick = FindObjectOfType<GameJoystickController>();
            _playerInput = GetComponent<PlayerInput>();
            
            _staminaSystem = FindObjectOfType<StaminaSystemController>();
            
            animationController.ChangeAnimationData(0);
        }
        private void Start()
        {
            //MovementSpeed = 0.5f;
            //_sprintSpeedMultiplier = 5f;
            
            _staminaSystem.Amount = staminaUseAmount;
            SetState(new IdlePlayerState(this));
        }

        private void Update()
        {
            MovementDirection = _playerInput.MovementInput(_joystick);
            Debug.Log(MovementDirection);
            _currentPlayerState.Tick();
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
            bool lastSpriteFlipStatus = animationController.ArmatureComponent._armature.flipX;
            if (MovementDirection.x < 0)
            {
                animationController.ArmatureComponent._armature.flipX = true;
            }
            else if (MovementDirection.x > 0)
            {
                animationController.ArmatureComponent._armature.flipX = false;
            }
            else
            {
                animationController.ArmatureComponent._armature.flipX = lastSpriteFlipStatus;
            }
        }

        public void SetState(PlayerState playerState)
        {
            _currentPlayerState?.OnStateExit();

            _currentPlayerState = playerState;

            _currentPlayerState?.OnStateEnter();
        }

        public Vector3 GetMovementDirection()
        {
            return MovementDirection;
        }
    }
}
