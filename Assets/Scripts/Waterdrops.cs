using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterdrops : MonoBehaviour
{ 
    Rigidbody2D rb;
    public Transform startPosition;
    public Vector3 startPositionOffset;

    public float knockbackPower = 100;
    public float knocbackDuration = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerParent")
        {
            rb.isKinematic = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerParent")
        {
            StartCoroutine(BodyMovement.instance.Knockback(knocbackDuration, knockbackPower, this.transform));
        }

        if (collision.gameObject.tag == "wall")
        {
            transform.position = startPosition.position + startPositionOffset;
        }
    }

}

