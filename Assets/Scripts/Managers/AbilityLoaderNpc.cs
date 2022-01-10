using System;
using Controllers.NPC;
using ScriptableData.Ability;
using UnityEngine;

namespace Managers
{
    public class AbilityLoaderNpc : MonoBehaviour
    {
        private SpawnManagerEnemy _spawnManager;
        [SerializeField] private NpcAbility npcAbility;

        private void Awake()
        {
            _spawnManager = GetComponent<SpawnManagerEnemy>();
        }

        private void Start()
        {
            var npc = _spawnManager.GetNpc();
            
            npc.SetFieldOfDetection(npcAbility.fieldOfView, npcAbility.viewDistance);
            npc.SetMovement(npcAbility.movementSpeed, npcAbility.sprintSpeedMultiplier);
        }
    }
}