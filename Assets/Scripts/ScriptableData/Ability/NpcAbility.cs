using UnityEngine;

namespace ScriptableData.Ability
{
    [CreateAssetMenu(fileName = "Npc Ability", menuName = "SO/NpcAbility", order = 1)]
    public class NpcAbility : ScriptableObject
    {
        public float movementSpeed;
        public float sprintSpeedMultiplier;

        public float fieldOfView;
        public float viewDistance;
    }
}