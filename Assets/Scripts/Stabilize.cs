using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilize : MonoBehaviour
{
    private Rigidbody2D _rigidBody = null;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

        // Update is called once per frame
        void Update()
    {
       // _rigidbody.AddForce(0, 10, 0);
    }
}
