using System;
using Interfaces;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class TreasureController : MonoBehaviour
    {
        private Rigidbody2D _treasureRigidbody;
        private PlayerController _player;
        private IWinnable _victoryManager;
        [SerializeField] private float _maxDistance = 3.0f;
        private float _timeStamp;

        private bool _isReachable;

        [SerializeField] private bool IsMainTreasure;

        private void Awake()
        {
            _treasureRigidbody = GetComponent<Rigidbody2D>();
            _victoryManager = FindObjectOfType<VictoryManager>();
        }

        private void Start()
        {
            _player = FindObjectOfType<PlayerController>();
            if (CompareTag("MainTreasure"))
            {
                IsMainTreasure = true;
            }
        }

        private void Update()
        {
            CheckPlayerDistanceToTreasure();
        }

        private void CheckPlayerDistanceToTreasure()
        {
            // cek posisi coin terhadap jarak ke player
            float distance = Vector3.Distance(transform.position, _player.transform.position);
            _isReachable = distance <= _maxDistance;
        }

        private void FixedUpdate()
        {
            MagnetizeTreasure();
        }

        private void MagnetizeTreasure()
        {
            if (_isReachable)
            {
                Vector3 targetDirection = (_player.transform.position - transform.position).normalized;
                RaycastHit2D raycastHit2D = 
                    Physics2D.Raycast(transform.position, targetDirection);
                if (raycastHit2D.collider.CompareTag("Wall"))
                {
                    return;
                }
                _timeStamp = Time.time;
                _treasureRigidbody.velocity =
                    new Vector2(targetDirection.x, targetDirection.y) * 10f * (Time.time / _timeStamp);
            }

            if (Vector3.Distance(transform.position, _player.transform.position) < 0.5f)
            {
                _player.AddTreasureNumber(1);
                DestroyTreasure();
            }
        }

        public void DestroyTreasure()
        {
            if (IsMainTreasure)
            {
                _victoryManager.SetIsMainTreasureGet(true);
            }

            Destroy(gameObject);
        }
    }
}
