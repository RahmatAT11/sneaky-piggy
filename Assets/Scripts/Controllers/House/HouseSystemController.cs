using System.Collections.Generic;
using UnityEngine;

namespace Controllers.House
{
    public class HouseSystemController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> mutableWalls;

        public delegate void PlayerEnter(bool isEnter);
        public static event PlayerEnter PlayerEntered;

        private void Start()
        {
            PlayerEntered += ShowInsideHouse;
        }

        private void OnDestroy()
        {
            PlayerEntered -= ShowInsideHouse;
        }

        private void ShowInsideHouse(bool isDoorOpen)
        {
            foreach (var wall in mutableWalls)
            {
                wall.GetComponent<SpriteRenderer>().enabled = !isDoorOpen;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerEntered?.Invoke(true);
                SoundManager.Instance.PlayBGM("BGM Dalam Rumah");
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerEntered?.Invoke(false);
                SoundManager.Instance.PlayBGM("BGM Dalem Rumah");
            }
        }
    }
}
