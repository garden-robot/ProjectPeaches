using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBasketball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "pickUp")
        {
            Debug.Log("Score!");
        }
    }
}


