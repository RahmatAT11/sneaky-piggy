using System;
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
        }

        private void Start()
        {
            var playerController = _spawnManager.GetSpawnPlayer();
            
            playerController.PlayerAbility = playerAbility;
        }
    }
}
