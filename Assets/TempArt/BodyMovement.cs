using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    [SerializeField] private string _thrustButton = "t";
    [SerializeField] private string _jumpButton = "g";
    [SerializeField] private string _directionButton = "1";
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpSpeed = 1f;
    [SerializeField] private GameObject _buttFire = null;
    [SerializeField] private GameObject _jumpFire = null;
   // [SerializeField] private bool _direction = false;

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
     

  

        {

            //THRUST
            if (Input.GetKey(_thrustButton))
            {
                _buttFire.SetActive(true);
                _rigidBody.velocity += (new Vector2(-_transform.right.x, -(_transform.right.y - 1)) * _speed);
            }
            else if (Input.GetKeyUp(_thrustButton))
            {
                _buttFire.SetActive(false);
                //_rigidBody.velocity = Vector2.zero;
            }

            //JUMP
            if (Input.GetKey(_jumpButton))
            {
                _jumpFire.SetActive(true);
                _rigidBody.velocity += (new Vector2(_transform.up.x, _transform.up.y) * _jumpSpeed);
            }
            else if (Input.GetKeyUp(_jumpButton))
            {
                _jumpFire.SetActive(false);
                //_rigidBody.velocity = Vector2.zero;
            }
            //CHANGE DIRECTION
            /*
            if (Input.GetKeyDown(_directionButton))
            {
                _direction = !_direction;
                if (_direction == true)
                {
                    _rigidBody.rotation.Set(_rigidBody.rotation.x, _rigidBody.rotation.y - 180, _rigidBody.rotation.z, _rigidBody.rotation.w);
                }
                else
                {
                    _rigidBody.rotation.Set(_rigidBody.rotation.x, _rigidBody.rotation.y + 180, _rigidBody.rotation.z, trans.rotation.w);
                }
            }
           */
        }
        
    }
}
