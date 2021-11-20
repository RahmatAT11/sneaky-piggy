using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Controllers;

namespace Sprint
{
    public class GameSprintController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private PlayerController _playerController;
        [SerializeField] private float sprintTimeDuration = 5f;
        private float _sprintTimeCounter;

        private Color _activeSprint;
        private Color _unactiveSprint;

        private bool _isSprintAllowed;

        private void Start()
        {
            _activeSprint = GetComponent<Image>().color;
            _playerController = FindObjectOfType<PlayerController>();
            _unactiveSprint = Color.grey;
            _sprintTimeCounter = sprintTimeDuration;
            _isSprintAllowed = true;
        }

        private void Update()
        {
            if (_playerController.IsSprinting && _isSprintAllowed)
            {
                _sprintTimeCounter -= Time.deltaTime;
            }

            if (_sprintTimeCounter < 0 && _isSprintAllowed)
            {
                _playerController.IsSprinting = false;
                StartCoroutine(WaitForNextSprint());
                _sprintTimeCounter = sprintTimeDuration;
            }
        }

        private IEnumerator WaitForNextSprint()
        {
            _isSprintAllowed = false;
            GetComponent<Image>().color = _unactiveSprint;
            yield return new WaitForSeconds(sprintTimeDuration);
            GetComponent<Image>().color = _activeSprint;
            _isSprintAllowed = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Sprint(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Sprint(false);
        }

        public void Sprint(bool isSprinting)
        {
            _playerController.IsSprinting = isSprinting;
        }
    }
}
