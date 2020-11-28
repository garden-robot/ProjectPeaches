using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public float breakingImpulse = 5.0f;    
    public float impulse;
     public bool alreadySmashed=false;

   
    
        public void GetImpactForce(Collision2D collision)
        {
            impulse = 0F;

            foreach (ContactPoint2D point in collision.contacts)
            {
             impulse = point.normalImpulse;
             //impulse = point.normalImpulse;
        }

    }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
        GetImpactForce(collision);

            if (alreadySmashed) return;
            if (impulse > breakingImpulse)
            {
                Debug.Log("Smash! I'm breaking up!");
                alreadySmashed = true;
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
