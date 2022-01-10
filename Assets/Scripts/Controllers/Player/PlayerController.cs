using System.Collections.Generic;
using UnityEngine;
using Controllers.Joystick;
using Controllers.Base;
using DragonBones;
using Interfaces.Player;
using ScriptableData.Ability;
using State.Direction;
using State.Direction.Player;
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
        [SerializeField] private List<BaseCharAnimationController> animationControllers;
        private UnityArmatureComponent _currentUac;
        
        // Player Component
        private IInputProcess _playerInput;
        private PlayerState _currentPlayerState;
        private DirectionPlayerState _currentDirectionPlayerState;

        private bool hasSprintSoundPlayed;
        private bool hasWalkSoundPlayed;

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
            
            SetCurrentUac(0);
            SetState(new IdlePlayerState(this));
            SetState(new SidePlayerState(this));
            
            _staminaSystem.Amount = staminaUseAmount;
        }

        public void SetUpPlayerAbility(PlayerAbility playerAbility)
        {
            staminaUseAmount = playerAbility.staminaUseAmount;
            MovementSpeed = playerAbility.movementSpeed;
            SprintSpeedMultiplier = playerAbility.sprintSpeedMultiplier;

            _staminaSystem.SetUpStaminaAbility(playerAbility.maxStamina, playerAbility.regenerateTick);
        }

        private void Update()
        {
            MovementDirection = _playerInput.MovementInput(_joystick);

            SoundBabiJalan();

            Debug.Log(MovementDirection);
            _currentPlayerState.Tick();
            _currentDirectionPlayerState.Tick();
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

                //SoundLari
                if (!hasSprintSoundPlayed)
                {
                    hasSprintSoundPlayed = true;
                    SoundManager.Instance.StopSFX("SFX Babi Jalan");
                    SoundManager.Instance.PlaySFX("SFX Babi Lari");
                }
            }
            if (!IsSprinting)
            {
                SoundManager.Instance.StopSFX("SFX Babi Lari");
                hasSprintSoundPlayed = false;
            }
        }

        protected override void Turning()
        {
            bool lastSpriteFlipStatus = _currentUac._armature.flipX;
            if (MovementDirection.x < 0)
            {
                _currentUac._armature.flipX = true;
            }
            else if (MovementDirection.x > 0)
            {
                _currentUac._armature.flipX = false;
            }
            else
            {
                _currentUac._armature.flipX = lastSpriteFlipStatus;
            }
        }

        public void SetState(PlayerState playerState)
        {
            _currentPlayerState?.OnStateExit();

            _currentPlayerState = playerState;

            _currentPlayerState?.OnStateEnter();
        }

        public void SetState(DirectionPlayerState directionPlayerState)
        {
            _currentDirectionPlayerState?.OnStateExit();

            _currentDirectionPlayerState = directionPlayerState;
            
            _currentDirectionPlayerState?.OnStateEnter();
        }

        public Vector3 GetMovementDirection()
        {
            return MovementDirection;
        }

        public void SetCurrentUac(int index)
        {
            if (index >= animationControllers.Count) return;

            animationControllers[index].SetActiveAnimation(true);
            _currentUac = animationControllers[index].ArmatureComponent;
        }

        public UnityArmatureComponent GetCurrentUac()
        {
            return _currentUac;
        }

        public List<BaseCharAnimationController> GetListOfAnimationControllers()
        {
            return animationControllers;
        }

        public void SoundBabiJalan()
        {
            if (MovementDirection != Vector3.zero)
            {
                if (!hasWalkSoundPlayed)
                {
                    hasWalkSoundPlayed = true;
                    SoundManager.Instance.PlaySFX("SFX Babi Jalan");
                }
            }
            if (MovementDirection == Vector3.zero)
            {
                SoundManager.Instance.StopSFX("SFX Babi Jalan");
                hasWalkSoundPlayed = false;
            }
        }
    }
}
