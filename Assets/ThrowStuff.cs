using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStuff : MonoBehaviour
{
    public GameObject projectile;
    public Transform bulletPoint;
    public float shotsPerSeconds;
    public GameObject player;

    public float shotDelay;
    [SerializeField] private float shotCounter;
    [SerializeField] private float constant;
    [SerializeField] private float torque;


    // Use this for initialization
    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
        shotCounter += Time.deltaTime;
        float probability = Time.deltaTime * shotsPerSeconds;

        // Debug.Log(shootOnDelay);
        //if (Random.value < probability) //random rate- no counter necessary
        if (shotCounter > shotDelay) //fixed rate
        {

            Fire();
            shotCounter = 0;

        }
    }
    void Fire()
    {
        GameObject bullet = Instantiate(projectile, bulletPoint.position, bulletPoint.rotation);
        var bullet_rb2d = bullet.GetComponent<Rigidbody2D>();
        var player_rb2d = player.GetComponent<Rigidbody2D>();

        bullet_rb2d.velocity = (player_rb2d.position - bullet_rb2d.position).normalized * constant;
        bullet_rb2d.AddTorque(100 + constant);
        bullet_rb2d.AddForce(transform.forward * constant);

        
    }

}