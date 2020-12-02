using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHealthManager : MonoBehaviour
{
    public float currentHealth; //between 0.0% - 100.0%
    public float maxHealth = 100.0f;
    public float deadHealth = 0.0f ;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentHealth);
        if (currentHealth == deadHealth)
        {
            //restart game
        }
    }
}
