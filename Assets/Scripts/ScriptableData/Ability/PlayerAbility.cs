using UnityEngine;

namespace ScriptableData.Ability
{
    [CreateAssetMenu(fileName = "Player Ability", menuName = "SO/PlayerAbility", order = 0)]
    public class PlayerAbility : ScriptableObject
    {
        public float movementSpeed;
        public float sprintSpeedMultiplier;
        
        public int staminaUseAmount;
        public int maxStamina;
        public float regenerateTick;
    }
}
