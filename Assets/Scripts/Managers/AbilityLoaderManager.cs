using ScriptableData.Ability;
using UnityEngine;

namespace Managers
{
    public class AbilityLoaderManager : MonoBehaviour
    {
        private SpawnManagerPlayer _spawnManager;
        [SerializeField] private PlayerAbility playerAbility;

        private void Awake()
        {
            _spawnManager = GetComponent<SpawnManagerPlayer>();
        }

        private void Start()
        {
            var playerController = _spawnManager.GetPlayer();
            
            playerController.SetUpPlayerAbility(playerAbility);
        }
    }
}
