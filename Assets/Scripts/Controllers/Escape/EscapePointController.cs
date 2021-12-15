using System;
using Interfaces;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class EscapePointController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                IWinnable victoryManager = FindObjectOfType<VictoryManager>();
                victoryManager.SetIsPlayerEscape(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                IWinnable victoryManager = FindObjectOfType<VictoryManager>();
                victoryManager.SetIsPlayerEscape(false);
            }
        }
    }
}