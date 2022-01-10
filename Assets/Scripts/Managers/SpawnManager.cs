using UnityEngine;
using Controllers.Base;
using Controllers.NPC;
using Controllers.Player;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private BaseCharController characterPrefab;
        private PlayerController _playerController;
        private NonPlayerController _nonPlayerController;

        private void Awake()
        {
            if (characterPrefab.gameObject.layer == LayerMask.GetMask("Enemy"))
            {
                _nonPlayerController = Instantiate(characterPrefab, transform.position, transform.rotation)
                    as NonPlayerController;
            }
            else
            {
                _playerController = Instantiate(characterPrefab, transform.position, transform.rotation)
                    as PlayerController;
            }
        }

        public NonPlayerController GetSpawnedNpc()
        {
            return _nonPlayerController;
        }

        public PlayerController GetSpawnPlayer()
        {
            return _playerController;
        }
    }
}
