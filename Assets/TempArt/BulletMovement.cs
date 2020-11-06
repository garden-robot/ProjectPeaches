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
        print(_transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //_transform.position += new Vector3(_direction.x, _direction.y, _direction.z) * _speed; 
        _transform.position += new Vector3(1f, 1f, 0f) * _speed;
        //_transform.rotation = _direction;
        //_direction * _speed;
        //_rigidBody.velocity = transform.TransformDirection(Vector3.zero * _speed);
    }
}
