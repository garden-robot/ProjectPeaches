using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterbowl : MonoBehaviour
{
    public float knockbackPower = 100;
    public float knockbackDuration = 1;

    private AudioSource source; // used for audio

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerParent")
        {
            Debug.Log("This is working");
            StartCoroutine(BodyMovement.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
            source.Play();

        }
    }
}