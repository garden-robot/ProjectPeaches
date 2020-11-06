using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRBMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody = null;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D wall)
    {
        if(wall.gameObject.tag == "wall"){
            _rigidBody.velocity = Vector2.zero;
        }
    }
}
