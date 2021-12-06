using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Controllers
{
    public class HouseSystemController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> mutableWalls;
        private RoofSystemController _roof;
        private bool _isWallMuted;
        private DoorSystemController _door;

        private void Start()
        {
            _roof = FindObjectOfType<RoofSystemController>();
            _door = FindObjectOfType<DoorSystemController>();
        }

        private void Update()
        {
            ShowInsideHouse();
        }

        private void ShowInsideHouse()
        {
            foreach (var wall in mutableWalls)
            {
                if (_isWallMuted)
                {
                    wall.GetComponent<SpriteRenderer>().enabled = false;
                    _door.GetComponentInChildren<SpriteRenderer>().enabled = false;
                }
                else
                {
                    wall.GetComponent<SpriteRenderer>().enabled = true;
                    _door.GetComponentInChildren<SpriteRenderer>().enabled = true;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isWallMuted = true;
                _roof.ShowRoof(false);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isWallMuted = false;
                _roof.ShowRoof(true);
            }
        }
    }
}
