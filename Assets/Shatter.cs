using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public float shatterHealth;

    public bool pickUp;

    [SerializeField] private float breakingImpulse = 5.0f;
    [SerializeField] private float impulse;
    public bool alreadySmashed = false;




    [SerializeField] private HouseHealthManager houseHealthManager;

    [SerializeField] private GameObject ParticleShatter;
    [SerializeField] private Collider2D ShatterCollider;

    // [SerializeField] private Animation anim;



    public void GetImpactForce(Collision2D collision)
    {
        impulse = 0F;
        if (collision.collider.tag == "PlayerParent" || collision.collider.tag == "CreepyGround")
        {
            if (pickUp)
            {
                foreach (ContactPoint2D point in collision.contacts)
                {
                    impulse = point.normalImpulse * 1000;
                    //impulse = point.normalImpulse;
                }
            }
            else
            {

                foreach (ContactPoint2D point in collision.contacts)
                {
                    impulse = point.normalImpulse;
                    //impulse = point.normalImpulse;
                }
            }
        }
        /*
        else
        {
            if (pickUp)
            {
                foreach (ContactPoint2D point in collision.contacts)
                {
                    impulse = point.normalImpulse * 10000;
                    //impulse = point.normalImpulse;
                }
            }

        }
        */
    }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            var particles = ParticleShatter.GetComponent<ParticleSystem>();
            float totalDuration = particles.duration + particles.startLifetime;
            GetImpactForce(collision);

            if (alreadySmashed) return;


            if (impulse > breakingImpulse)
            {

                alreadySmashed = true;
                this.transform.parent = null;


            if (collision.collider.tag == "PlayerParent" || collision.collider.tag == "CreepyGround") {
                   
                    Destroy(ShatterCollider);

                    //Destroy(gameObject.GetComponent<Rigidbody2D>());

                    Debug.Log("Smash! I'm breaking up!");

                    //anim.Play("shakeUI");

                    Destroy(gameObject.GetComponent<SpriteRenderer>());

                    particles.Play();

                    Destroy(gameObject, totalDuration);

                    var house_health = houseHealthManager.currentHealth;
                    if (house_health != null)
                    {
                        house_health = house_health - shatterHealth;
                        houseHealthManager.currentHealth = house_health;
                    }
                    else
                    {
                        Debug.Log("house_health is null!");
                    }

                }
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (alreadySmashed) return;
            if (impulse > breakingImpulse)
            {
                string s = "Too heavy, I'm breaking up!";


                if (collision.rigidbody.isKinematic)
                    s += "Under my own weight";
                else
                    s += "under the weight of " + collision.rigidbody.gameObject.name;
                Debug.Log(s);
                alreadySmashed = true;
            }
        }

    }
