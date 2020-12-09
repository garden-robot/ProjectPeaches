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
    [SerializeField] private Rigidbody2D[] allChildren;

    public LookTowardMouse _lookTowardMouse;
    private Rigidbody2D _rigidBody = null;
    private Transform _transform = null;

    public static BodyMovement instance; // used for knockback script

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _buttFire.SetActive(false);
        _jumpFire.SetActive(false);
        // HingeJoint2D[] allChildren = GetComponentsInChildren<HingeJoint2D>();
        Rigidbody2D[] allChildren = GetComponentsInChildren<Rigidbody2D>();

        /*
        foreach (Transform child in allChildren)
        {
            HingeJoint2D hinge = child.GetComponent<HingeJoint2D>();
            //ConnectedAnchor2D anchor = hinge.connectedanchor;

        }
        */
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
                _rigidBody.velocity += (new Vector2(-_transform.right.x, -(_transform.right.y)) * _speed);

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
                _rigidBody.velocity += (new Vector2(_transform.right.x, (_transform.right.y)) * _speed);

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


            if ((Input.GetKeyDown(_thrustButton) && _bodyFlip.transform.localScale.x == -1f || Input.GetKeyDown(_thrustButton_right) && _bodyFlip.transform.localScale.x == 1f))
            {
                _bodyFlip.transform.localScale =
                  new Vector3(
                  -_bodyFlip.transform.localScale.x,
                  _bodyFlip.transform.localScale.y,
                  _bodyFlip.transform.localScale.z);
                foreach (Rigidbody2D child in allChildren)
                {
                    if (child.constraints == RigidbodyConstraints2D.None)
                    {
                        child.constraints = RigidbodyConstraints2D.FreezeRotation;
                    }
                }




            }

            foreach (Rigidbody2D child in allChildren)
            {
                if (child.constraints == RigidbodyConstraints2D.FreezeRotation)
                {
                    child.constraints = RigidbodyConstraints2D.None;
                }
            }
            if (_bodyFlip.transform.localScale.x == -1f)
            {
                _lookTowardMouse.angleOffset = 0;
            }
            if (_bodyFlip.transform.localScale.x == 1f)
            {
                _lookTowardMouse.angleOffset = 180;
            }
            /*
            foreach (HingeJoint2D child in allChildren)
            {
                Debug.Log("check");




                // HingeJoint2D hinge = child.GetComponent<HingeJoint2D>();

                if (child.useLimits == true)
                {
                    child.constraints = RigidbodyConstraints2D.FreezeRotation;

                    Debug.Log("true");
                    JointAngleLimits2D limits = child.limits;
                    Debug.Log(limits.min);
                    child.useLimits = false;


                    if (_bodyFlip.transform.localScale.x == -1f)
                    {
                        limits.min = 180 - limits.min;
                        limits.max = 180 - limits.max;
                    }

                }
                */
            //neck and leg mode options
            //moochi's- 'virtuoso'
            //'turbo' mode
            //movement not so linear, make it feel
            //hold button longer make it quicker




        }

    }

    public IEnumerator Knockback (float knockbackDuration, float knockbackPower, Transform obj) // knocks peaches back when hitting water
    {
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            _rigidBody.AddForce(-direction * knockbackPower);
        }
        yield return 0;
    }
        
 
}

