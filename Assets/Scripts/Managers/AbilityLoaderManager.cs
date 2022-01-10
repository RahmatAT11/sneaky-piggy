using Controllers.Player;
using ScriptableData.Ability;
using UnityEngine;

namespace Managers
{
    public class AbilityLoaderManager : MonoBehaviour
    {
        private SpawnManager _spawnManager;
        [SerializeField] private PlayerAbility playerAbility;

        private void Awake()
        {
            _spawnManager = GetComponent<SpawnManager>();

            if (_spawnManager.GetCharacterSpawned().gameObject.CompareTag("Player")) return;
            PlayerController playerController = _spawnManager.GetCharacterSpawned() as PlayerController;
            
            if (playerController == null) return;
            playerController.PlayerAbility = playerAbility;
        }
    }
}
