using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseHealthManager : MonoBehaviour
{
    public float currentHealth; //between 0.0% - 100.0%
    public float maxHealth = 100.0f;
    public float deadHealth = 0.0f ;

    private float _initialScale = 1000f;
    private Image _healthBar = null;
    // Start is called before the first frame update
    void Start()
    {
        _healthBar = GetComponent<Image>();
        currentHealth = maxHealth;
        _initialScale = _healthBar.fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        //set bar length based on health
        float newX = ((currentHealth* _initialScale)/maxHealth);
        //Vector3 newScale = new Vector3(newX, _healthBar.fillAmount.y, _healthBar.fillAmount.z);
        _healthBar.fillAmount = newX;

        //death check
        if (currentHealth == deadHealth)
        {
            //restart game
        }
    }
}
