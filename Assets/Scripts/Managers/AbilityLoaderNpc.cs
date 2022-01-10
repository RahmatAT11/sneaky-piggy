using System;
using Controllers.NPC;
using ScriptableData.Ability;
using UnityEngine;

namespace Managers
{
    public class AbilityLoaderNpc : MonoBehaviour
    {
        private SpawnManager _spawnManager;
        [SerializeField] private NpcAbility npcAbility;

        private void Awake()
        {
            _spawnManager = GetComponent<SpawnManager>();
        }

        private void Start()
        {
            var npc = _spawnManager.GetSpawnedNpc();
            
            npc.SetFieldOfDetection(npcAbility.fieldOfView, npcAbility.viewDistance);
            npc.SetMovement(npcAbility.movementSpeed, npcAbility.sprintSpeedMultiplier);
        }
    }
}