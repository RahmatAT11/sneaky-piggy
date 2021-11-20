using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPickManager : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private PlayerController _player;
    private Vector2 _targetDirection;
    private float _timeStamp;
    private bool _isMagnetic;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isMagnetic)
        {
            _targetDirection =- (transform.position - _player.transform.position).normalized;

            _rigidbody2D.velocity = new Vector2(_targetDirection.x, _targetDirection.y) * 10f * (Time.time / _timeStamp);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals ("Treasure Magnetic"))
        {
            _timeStamp = Time.time;
            _player = FindObjectOfType<PlayerController>();;
            _isMagnetic = true;
        }
    }
}
