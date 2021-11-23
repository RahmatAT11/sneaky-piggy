using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class DoorSystemController : MonoBehaviour
    {
        private GameObject _door;
        private bool _isDoorOpened;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isDoorOpened = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isDoorOpened = false;
            }
        }
    }
}
