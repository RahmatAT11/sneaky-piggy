using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Controllers
{
    public class HouseSystemController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> mutableWalls;
        private List<GameObject> _walls;
        private GameObject _roof;
        private Transform _playerTransform;
        private bool _isWallMuted;

        private void Start()
        {
            _walls = GameObject.FindGameObjectsWithTag("Wall").ToList();
            _roof = GameObject.FindWithTag("Roof");
            _playerTransform = FindObjectOfType<PlayerController>().transform;
        }

        private void Update()
        {
            ShowInsideHouse();
        }

        private void ShowInsideHouse()
        {
            foreach (var wall in mutableWalls)
            {
                float offsetYWall = wall.transform.lossyScale.y / 2;
                float positionYWall = transform.position.y;
                if (_playerTransform.position.y > positionYWall - Mathf.Pow(offsetYWall, 5))
                {
                    _isWallMuted = true;
                }
                else
                {
                    _isWallMuted = false;
                }

                if (_isWallMuted)
                {
                    wall.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    wall.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
    }
}
