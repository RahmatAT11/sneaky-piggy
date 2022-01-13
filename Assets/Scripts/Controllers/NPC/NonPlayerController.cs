using System.Collections;
using System.Collections.Generic;
using Controllers.Player;
using Controllers.Base;
using DragonBones;
using Interfaces;
using Managers;
using State.Direction;
using State.Direction.NonPlayer;
using State.NPC;
using UnityEngine;
using Transform = UnityEngine.Transform;

namespace Controllers.NPC
{
    public class NonPlayerController : BaseCharController
    {
        private List<Transform> _defaultPath;
        private PathsController _paths;
        private PlayerController _player;
        private FieldOfView _fieldOfView;

        private float _distance;

        private int _currentPathIndex;

        private bool _isMoveToNewPath;
        private bool _isPlayerDetected;
        public bool IsStandingStill { get; set; }
        public bool IsPlayerDetected => _isPlayerDetected;

        private IWinnable _victoryManager;

        [SerializeField] private List<BaseCharAnimationController> animationControllers;

        private NpcState _currentState;
        private DirectionNonPlayerState _currentDirectionState;
        private UnityArmatureComponent _currentUac;

        private Transform _lookDirection;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            _victoryManager = FindObjectOfType<VictoryManager>();

            IsStandingStill = true;
        }

        private void Start()
        {
            SetCurrentUac(0);
            SetState(new IdleNpcState(this));
            SetState(new SideNonPlayerState(this));
        }

        private void Update()
        {
            _currentState.Tick();
            _currentDirectionState.Tick();
            _fieldOfView.SetOrigin(transform.localPosition);
            _fieldOfView.SetAimDirection(_lookDirection.position);
        }

        public void LookDirection()
        {
            if (IsStandingStill)
            {
                Vector3 lookAt = _defaultPath[0].position;
                _lookDirection.position = (lookAt - transform.position).normalized;
            }
        }

        public void MoveNpcToPlayer()
        {
            SoundManager.Instance.PlaySFX("SFX Random");
            MovementDirection = (_player.transform.position - transform.position).normalized;
            _victoryManager.SetIsPlayerDetected(true);
        }

        public void DetectPlayer()
        {
            _player = _fieldOfView.DetectedPlayer;
            _isPlayerDetected = _player != null;
        }

        public void MoveNpcToPath()
        {
            _distance = Vector3.Distance(_defaultPath[_currentPathIndex].position, transform.position);
            if (_distance < 0.1f)
            {
                _currentPathIndex++;
                CheckIndexPath();
            }
            else
            {
                _isMoveToNewPath = true;
                if (_isMoveToNewPath)
                {
                    MovementDirection = (_defaultPath[_currentPathIndex].position - transform.position).normalized;
                    _lookDirection.position = MovementDirection;
                    StartCoroutine(WaitForNextPathAvailable());
                }
            }
        }

        private void FixedUpdate()
        {
            Walking();
            Sprinting();
            Turning();
        }

        protected override void Turning()
        {
            bool lastSpriteFlipStatus = _currentUac._armature.flipX;
            if (_lookDirection.position.x < 0)
            {
                _currentUac._armature.flipX = true;
            }
            else if (_lookDirection.position.x > 0)
            {
                _currentUac._armature.flipX = false;
            }
            else
            {
                _currentUac._armature.flipX = lastSpriteFlipStatus;
            }
        }

        protected override void Sprinting()
        {
            if (IsSprinting)
            {
                base.Sprinting();
            }
        }

        private void CheckIndexPath()
        {
            if (_currentPathIndex > _defaultPath.Count - 1)
            {
                _currentPathIndex = 0;
            }
        }

        private IEnumerator WaitForNextPathAvailable()
        {
            _isMoveToNewPath = false;
            yield return new WaitUntil(() => { return _distance < 0.1f; });
            _isMoveToNewPath = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player == null)
                return;

            if (player.IsSprintingEx)
            {
                _isPlayerDetected = true;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _victoryManager.SetIsCatchByNpc(true);
            }
        }

        public void SetState(NpcState state)
        {
            _currentState?.OnStateExit();

            _currentState = state;

            _currentState?.OnStateEnter();
        }
        
        public void SetState(DirectionNonPlayerState state)
        {
            _currentDirectionState?.OnStateExit();

            _currentDirectionState = state;

            _currentDirectionState?.OnStateEnter();
        }

        public int GetDefaultPathSize()
        {
            return _defaultPath.Count;
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

        public void SetFieldOfDetection(float fieldOfView, float viewDistance)
        {
            _fieldOfView.SetFov(fieldOfView);
            _fieldOfView.SetViewDistance(viewDistance);
        }

        public void SetMovement(float movementSpeed, float sprintSpeedMultiplier)
        {
            this.MovementSpeed = movementSpeed;
            this.SprintSpeedMultiplier = sprintSpeedMultiplier;
        }

        public void SetLookDirection(Transform dir)
        {
            _lookDirection = dir;
        }

        public void SetFovObject(FieldOfView fov)
        {
            _fieldOfView = fov;
        }

        public void SetPaths(PathsController paths)
        {
            _paths = paths;
            _defaultPath = _paths.NpcPath;
        }
    }
}
