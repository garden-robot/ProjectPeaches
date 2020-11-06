using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _player = null;
    private Transform _transform = null;
    private Rigidbody2D _rigidBody = null;
    private Quaternion _direction;

    void Awake()
    {
        _transform = GetComponent<Transform>();
        _direction = _player.rotation;
        _transform.rotation = _direction;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position += _transform.right * _speed;
    }
}
