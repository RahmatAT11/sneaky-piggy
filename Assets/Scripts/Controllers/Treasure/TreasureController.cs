using Controllers.Player;
using Interfaces;
using Managers;
using UnityEngine;

namespace Controllers.Treasure
{
    public class TreasureController : MonoBehaviour
    {
        private Rigidbody2D _treasureRigidbody;
        private TreasureCollectorController _treasureCollector;
        private Transform _player;
        private IWinnable _victoryManager;
        [SerializeField] private float maxDistance = 3.0f;
        private float _timeStamp;

        private bool _isReachable;

        [SerializeField] private bool isMainTreasure;

        private void Awake()
        {
            _treasureRigidbody = GetComponent<Rigidbody2D>();
            _victoryManager = FindObjectOfType<VictoryManager>();
        }

        private void Start()
        {
            _player = FindObjectOfType<PlayerController>().transform;
            _treasureCollector = FindObjectOfType<TreasureCollectorController>();
            if (CompareTag("MainTreasure"))
            {
                isMainTreasure = true;
            }
        }

        private void Update()
        {
            CheckPlayerDistanceToTreasure();
        }

        private void CheckPlayerDistanceToTreasure()
        {
            // cek posisi coin terhadap jarak ke player
            float distance = Vector3.Distance(transform.position, _player.position);
            _isReachable = distance <= maxDistance;
        }

        private void FixedUpdate()
        {
            MagnetizeTreasure();
        }

        private void MagnetizeTreasure()
        {
            if (_isReachable)
            {
                Vector3 currentTreasurePosition = transform.position;
                Vector3 targetDirection = (_player.position - currentTreasurePosition).normalized;
                RaycastHit2D raycastHit2D = 
                    Physics2D.Raycast(currentTreasurePosition, targetDirection);
                if (raycastHit2D.collider.CompareTag("Wall"))
                {
                    return;
                }
                _timeStamp = Time.time;
                _treasureRigidbody.velocity =
                    new Vector2(targetDirection.x, targetDirection.y) * (10f * (Time.time / _timeStamp));
            }

            if (Vector3.Distance(transform.position, _player.position) < 0.5f)
            {
                _treasureCollector.AddTreasureNumber(1);
                DestroyTreasure();
            }
        }

        private void DestroyTreasure()
        {
            if (isMainTreasure)
            {
                _victoryManager.SetIsMainTreasureGet(true);
            }

            Destroy(gameObject);
        }
    }
}
