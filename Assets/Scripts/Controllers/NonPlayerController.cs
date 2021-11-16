using System;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerController : BaseCharController
{
    [SerializeField] private List<Transform> defaultPath;
    private PathsController _paths;

    private int _currentPathIndex = 0;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _paths = FindObjectOfType<PathsController>();
        defaultPath = _paths.NpcPath;
    }

    private void Start()
    {
        transform.position = defaultPath[_currentPathIndex].transform.position;
    }
}
