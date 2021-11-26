using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Controllers;
using UnityEngine.UI;

namespace Controllers.Sprint
{
    public class GameSprintController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private PlayerController _player;
        private StaminaSystemController _staminaSystem;

        private void Start()
        {
            _player = FindObjectOfType<PlayerController>(true);
            _staminaSystem = gameObject.GetComponent<StaminaSystemController>();
        }

        private void Update()
        {
            if (_staminaSystem.IsStaminaEmpty && _player.IsSprinting)
            {
                Sprint(false);
                Debug.Log(false);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Sprint(true);
            Debug.Log(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Sprint(false);
        }

        private void Sprint(bool isSprinting)
        {
            _player.IsSprinting = isSprinting;
        }
    }
}
