using UnityEngine;

namespace Controllers
{
    public class DoorSystemController : MonoBehaviour
    {
        [SerializeField] private Animator door;
        private bool _isDoorOpened;
        public bool IsDoorOpened
        {
            get
            {
                return _isDoorOpened;
            }
        }

        private void Update()
        {
            if (!_isDoorOpened)
            {
                door.SetBool("IsDoorOpen", _isDoorOpened);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isDoorOpened = true;
                door.SetTrigger("IsPlayerEnter");
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_isDoorOpened)
            {
                door.SetBool("IsDoorOpen", _isDoorOpened);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isDoorOpened = false;
                door.SetTrigger("IsPlayerExit");
            }
        }
    }
}
