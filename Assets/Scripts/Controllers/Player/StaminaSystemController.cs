using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.Player
{
    public class StaminaSystemController : MonoBehaviour
    {
        [SerializeField] private int maxStamina = 100;
        [SerializeField] private int currentStamina;
        [SerializeField] private float regenerateTick = 0.1f;

        private WaitForSeconds _regenTick;
        private Coroutine _regen;

        private Slider _sprintButton;
        
        public int Amount { get; set; }
        public bool IsStaminaEmpty { get; private set; }

        private void Awake()
        {
            _regenTick = new WaitForSeconds(regenerateTick);
        }

        private void Start()
        {
            _sprintButton = GetComponent<Slider>();
            currentStamina = maxStamina;
            _sprintButton.maxValue = maxStamina;
            _sprintButton.value = maxStamina;
        }

        private void Update()
        {
            IsStaminaEmpty = currentStamina  <= 0;
            DeactivatedGameObject();
        }

        public void UseStamina(int amount)
        {
            if (currentStamina - amount >= 0)
            {
                currentStamina -= amount;
                _sprintButton.value = currentStamina;

                if (_regen != null)
                {
                    StopCoroutine(_regen);
                }
                _regen = StartCoroutine(RegenerateStamina());
            }
        }

        private void DeactivatedGameObject()
        {
            if(gameObject.activeInHierarchy) return;
            
            StopCoroutine(RegenerateStamina());
        }

        private IEnumerator RegenerateStamina()
        {
            yield return new WaitForSeconds(0.5f);

            while (currentStamina < maxStamina)
            {
                currentStamina += Amount;
                _sprintButton.value = currentStamina;

                yield return _regenTick;
            }

            _regen = null;
        }
    }
}