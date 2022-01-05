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
        public bool IsPlayerDetected => _isPlayerDetected;

        private IWinnable _victoryManager;

        [SerializeField] private List<BaseCharAnimationController> animationControllers;

        private NpcState _currentState;
        private DirectionNonPlayerState _currentDirectionState;
        private UnityArmatureComponent _currentUac;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            _paths = FindObjectOfType<PathsController>();
            _fieldOfView = FindObjectOfType<FieldOfView>();
            _victoryManager = FindObjectOfType<VictoryManager>();
            
            _defaultPath = _paths.NpcPath;
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
            _fieldOfView.SetOrigin(transform.position);
            _fieldOfView.SetAimDirection(transform.up);
        }

        public void MoveNpcToPlayer()
        {
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
    }
}
