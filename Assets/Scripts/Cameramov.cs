using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramov : MonoBehaviour
{
    // public Transform cameraObject;
    public Transform background;
    public Vector3 cameraOffset;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Camera.main.transform.position = background.position + cameraOffset;
        }
    }
}
