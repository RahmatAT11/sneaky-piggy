using System.Collections;
using System.Collections.Generic;
using Controllers.Player;
using Controllers.Base;
using Interfaces;
using Managers;
using State.NPC;
using UnityEngine;

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

        private NpcState _currentState;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            _paths = FindObjectOfType<PathsController>();
            _defaultPath = _paths.NpcPath;
            _fieldOfView = FindObjectOfType<FieldOfView>();
            _victoryManager = FindObjectOfType<VictoryManager>();
        }

        private void Start()
        {
            SetState(new FollowPathNpcState(this));
        }

        private void Update()
        {
            _currentState.Tick();
            _fieldOfView.SetOrigin(transform.position);
            _fieldOfView.SetAimDirection(MovementDirection);
        }

        public void MoveNpcToPlayer()
        {
            _victoryManager.SetIsPlayerDetected(true);
            MovementDirection = (_player.transform.position - transform.position).normalized;
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
    }
}
