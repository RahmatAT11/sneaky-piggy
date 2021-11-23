using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Controllers
{
    public class HouseSystemController : MonoBehaviour
    {
        private List<GameObject> _walls;
        private GameObject _roof;

        private void Start()
        {
            _walls = GameObject.FindGameObjectsWithTag("Wall").ToList();
            _roof = GameObject.FindWithTag("Roof");
        }
    }
}
