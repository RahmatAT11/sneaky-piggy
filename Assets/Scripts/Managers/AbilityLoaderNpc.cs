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

            if (_spawnManager.GetCharacterSpawned().gameObject.layer != LayerMask.GetMask("Enemy")) return;
            NonPlayerController npc = _spawnManager.GetCharacterSpawned() as NonPlayerController;
            
            if (npc == null) return;
            npc.SetFieldOfDetection(npcAbility.fieldOfView, npcAbility.viewDistance);
            npc.SetMovement(npcAbility.movementSpeed, npcAbility.sprintSpeedMultiplier);
        }
    }
}