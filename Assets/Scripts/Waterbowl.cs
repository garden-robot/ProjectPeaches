using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterbowl : MonoBehaviour
{
    public Transform doghouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D activator)
    {
        Debug.Log("AHH WATER!");

        if (activator.tag == "Player")
        {
            activator.transform.position = doghouse.position;
        }
    }
}
