using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerController : BaseCharController
{
    [SerializeField] private List<Transform> defaultPath;
    private PathsController _paths;
    
    private float _detectionRadius = 5.0f;
    private float _detectionAngle = 170.0f;
    private float _distance;

    private int _currentPathIndex = 0;
    
    private bool _isMoveToNewPath;

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

    private void Update()
    {
        CheckIndexPath();
        MoveNpcToPath();
    }

    private void MoveNpcToPath()
    {
        _distance = Vector3.Distance(defaultPath[_currentPathIndex].position, transform.position);
        if (_distance < 0.1f)
        {
            _currentPathIndex++;
        }
        else
        {
            _isMoveToNewPath = true;
            if (_isMoveToNewPath)
            {
                MovementDirection = (defaultPath[_currentPathIndex].position - transform.position).normalized;
                StartCoroutine(WaitForNextPathAvailable());
            }
        }
    }

    private void FixedUpdate()
    {
        Walking();
        Turning();
    }

    private void CheckIndexPath()
    {
        if (_currentPathIndex > defaultPath.Count - 1)
        {
            _currentPathIndex = 0;
        }
    }

    protected override void Sprinting()
    {
        Rigidbody2D.velocity = MovementDirection * (MovementSpeed * _sprintSpeedMultiplier);
    }
    
    private IEnumerator WaitForNextPathAvailable()
    {
        _isMoveToNewPath = false;
        yield return new WaitUntil(() => { return _distance < 0.1f;});
        _isMoveToNewPath = true;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Color c = new Color(0.8f, 0, 0, 0.4f);
        UnityEditor.Handles.color = c;

        Vector3 rotatedForward = Quaternion.Euler(
            0,
            0,
            -_detectionAngle * 0.5f) * transform.up;

        UnityEditor.Handles.DrawSolidArc(
            transform.position,
            Vector3.forward,
            rotatedForward,
            _detectionAngle,
            _detectionRadius);
    }
#endif
}
