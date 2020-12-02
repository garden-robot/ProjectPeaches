using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAndDestroyOnCollision : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private float playerHitForce;
    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.collider.tag == "CreepyGround")
       // {
            GameObject.Destroy(gameObject, waitTime);
       // }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerParent")
        {
            collision.rigidbody.AddRelativeForce(transform.forward * playerHitForce);
        }
        
    }
}
