using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "pickUp")
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());
        }

    }
}