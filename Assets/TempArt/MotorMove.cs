using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorMove : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 1f;
    [SerializeField] private float _backSpeed = 1f;
    [SerializeField] private float _waitTime = 0f;
    [SerializeField] private string _backwardKey = "j";
    [SerializeField] private string _forwardKey = "k";
    private float _waiting = 0f;
    private bool _backwards = true;
    private HingeJoint2D _hingeJoint = null;
    private JointMotor2D _jointMotor;

    // Start is called before the first frame update
    void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint2D>();
        _jointMotor = _hingeJoint.motor;
    }

    void Update()
    {   
        if (Input.GetKeyDown(_backwardKey)){
            //print(_backwardKey);
            _jointMotor.motorSpeed = _backSpeed;
            _hingeJoint.motor = _jointMotor;
        }else if(Input.GetKeyUp(_backwardKey)){
            //print(_backwardKey);
            _jointMotor.motorSpeed = 0f;
            _hingeJoint.motor = _jointMotor;
        }
        
        if (Input.GetKeyDown(_forwardKey)){
            //print(_forwardKey);
            _jointMotor.motorSpeed = _forwardSpeed;
            _hingeJoint.motor = _jointMotor;
        }else if(Input.GetKeyUp(_forwardKey)){
            //print(_forwardKey);
            _jointMotor.motorSpeed = 0f;
            _hingeJoint.motor = _jointMotor;
        }
    }
}
