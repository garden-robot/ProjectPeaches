using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    [SerializeField] private string _thrustButton = "t";
    [SerializeField] private string _jumpButton = "g";
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpSpeed = 1f;
    [SerializeField] private GameObject _buttFire = null;
    [SerializeField] private GameObject _jumpFire = null;

    private Rigidbody2D _rigidBody = null;
    private Transform _transform = null;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _buttFire.SetActive(false);
        _jumpFire.SetActive(false);
    }

    void Update()
    {
        //THRUST
        if(Input.GetKey(_thrustButton))
        {
            _buttFire.SetActive(true);
            _rigidBody.velocity += (new Vector2(-_transform.right.x, -(_transform.right.y - 1)) * _speed);
        }else if(Input.GetKeyUp(_thrustButton)){
            _buttFire.SetActive(false);
            //_rigidBody.velocity = Vector2.zero;
        }

        //JUMP
        if(Input.GetKey(_jumpButton))
        {
            _jumpFire.SetActive(true);
            _rigidBody.velocity += (new Vector2(_transform.up.x, _transform.up.y) * _jumpSpeed);
        }else if(Input.GetKeyUp(_jumpButton)){
            _jumpFire.SetActive(false);
            //_rigidBody.velocity = Vector2.zero;
        }
    }
}
