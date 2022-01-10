using Controllers.Player;
using Interfaces;
using UnityEngine;

namespace Managers
{
    public class SpawnManagerPlayer : MonoBehaviour, ISpawnCharacter
    {
        [SerializeField] private PlayerController player;
        private PlayerController _currentPlayerHold;

        private void Awake()
        {
            SpawnCharacter();
        }

        public void SpawnCharacter()
        {
            _currentPlayerHold = Instantiate(player, transform.position, transform.rotation);
        }

        public PlayerController GetPlayer()
        {
            return _currentPlayerHold;
        }
    }
}