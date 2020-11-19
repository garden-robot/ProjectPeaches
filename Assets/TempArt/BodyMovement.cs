using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    [SerializeField] private string _thrustButton = "t";
    [SerializeField] private string _jumpButton = "g";
    [SerializeField] private string _thrustButton_right = "v";
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpSpeed = 1f;
    [SerializeField] private GameObject _buttFire = null;
    [SerializeField] private GameObject _jumpFire = null;
    [SerializeField] private string _direction = "left";
    [SerializeField] private GameObject _bodyFlip;

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
            if (Input.GetKey(_thrustButton)) // left
            {
                _buttFire.SetActive(true);
                /*
                if (BodyFlip.transform.rotation.y == 180)
                {
                    BodyFlip.transform.Rotate(0, 0,0, Space.Self);
                    
                }*/
                _rigidBody.velocity += (new Vector2(-_transform.right.x, -(_transform.right.y + 1)) * _speed);

            }
            else if (Input.GetKeyUp(_thrustButton))
            {
                _buttFire.SetActive(false);
                //_rigidBody.velocity = Vector2.zero;
            }
            if (Input.GetKey(_thrustButton_right)) // right
            {
                _buttFire.SetActive(true);

                /*
                if (BodyFlip.transform.rotation.y == 0)
                {
                    BodyFlip.transform.Rotate(0, 180,0, Space.Self);
                    
                }
                */
                _rigidBody.velocity += (new Vector2(_transform.right.x, (_transform.right.y -1 )) * _speed);
            }
            else if (Input.GetKeyUp(_thrustButton_right))
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
            
            if((Input.GetKeyDown(_thrustButton) && _bodyFlip.transform.localScale.x == -1f) || (Input.GetKeyDown(_thrustButton_right) && _bodyFlip.transform.localScale.x == 1f))
            {
                _bodyFlip.transform.localScale = 
                    new Vector3(
                    -_bodyFlip.transform.localScale.x, 
                    _bodyFlip.transform.localScale.y, 
                    _bodyFlip.transform.localScale.z);

                print(_direction);
            }
        }
        
    }
}
