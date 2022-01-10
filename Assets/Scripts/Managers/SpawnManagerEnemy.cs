using Controllers.NPC;
using Interfaces;
using UnityEngine;

namespace Managers
{
    public class SpawnManagerEnemy : MonoBehaviour, ISpawnCharacter
    {
        [SerializeField] private NonPlayerController npc;
        private NonPlayerController _currentNpcHold;

        private void Awake()
        {
            SpawnCharacter();
        }

        public void SpawnCharacter()
        {
            _currentNpcHold = Instantiate(npc, transform.position, transform.rotation);
        }

        public NonPlayerController GetNpc()
        {
            return _currentNpcHold;
        }
    }
}