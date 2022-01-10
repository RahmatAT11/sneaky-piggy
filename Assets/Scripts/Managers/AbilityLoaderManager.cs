using Controllers.Player;
using ScriptableData.Ability;
using UnityEngine;

namespace Managers
{
    public class AbilityLoaderManager : MonoBehaviour
    {
        [SerializeField] private PlayerAbility levelPlayerAbility;

        private void Start()
        {
            PlayerController.OnLevelLoaded += LoadPlayerAbility;
        }

        private void OnDestroy()
        {
            PlayerController.OnLevelLoaded -= LoadPlayerAbility;
        }

        private PlayerAbility LoadPlayerAbility()
        {
            return levelPlayerAbility;
        }
    }
}
