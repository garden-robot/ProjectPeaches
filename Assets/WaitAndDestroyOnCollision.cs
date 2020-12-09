using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAndDestroyOnCollision : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private float playerHitForce;

    void Awake()
    {
        Physics2D.IgnoreLayerCollision(12,13);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerParent")
        {
            collision.rigidbody.AddRelativeForce(transform.forward * playerHitForce);
        }
        else if (collision.collider.tag == "Shatterable" || collision.collider.tag == "Knockable")
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Shatterable" || collision.collider.tag == "Knockable")
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());
        }

        GameObject.Destroy(gameObject, waitTime);
        // }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.GetComponent<Collider>().tag == "Shatterable" || collision.GetComponent<Collider>().tag == "Knockable")
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), this.GetComponent<Collider2D>(),true);
        }
    }
}
