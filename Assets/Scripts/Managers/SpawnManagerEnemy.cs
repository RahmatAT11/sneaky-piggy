using Controllers;
using Controllers.NPC;
using Interfaces;
using UnityEngine;

namespace Managers
{
    public class SpawnManagerEnemy : MonoBehaviour, ISpawnCharacter
    {
        [SerializeField] private NonPlayerController npc;
        [SerializeField] private Transform lookDirection;
        [SerializeField] private FieldOfView fieldOfDetection;
        [SerializeField] private PathsController paths;
        private NonPlayerController _currentNpcHold;

        private void Awake()
        {
            SpawnCharacter();
        }

        public void SpawnCharacter()
        {
            _currentNpcHold = Instantiate(npc, transform.position, transform.rotation);
            _currentNpcHold.SetLookDirection(lookDirection);
            _currentNpcHold.SetFovObject(fieldOfDetection);
            _currentNpcHold.SetPaths(paths);
        }

        public NonPlayerController GetNpc()
        {
            return _currentNpcHold;
        }
    }
}