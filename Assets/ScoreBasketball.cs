using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBasketball : MonoBehaviour
{
    public GameObject chompActive;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "ball" && chompActive.activeInHierarchy == false  )
        {
            Debug.Log("Score!");
        }
    }
}


