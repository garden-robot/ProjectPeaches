using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterbowl : MonoBehaviour
{
    public float knockbackPower = 100;
    public float knockbackDuration = 1;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D activator)
    {
        if (activator.tag == "PlayerParent")
        {
            StartCoroutine(BodyMovement.instance.Knockback(knockbackDuration, knockbackPower, this.transform));
        }
    }
}
