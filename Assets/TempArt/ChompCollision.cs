using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChompCollision : MonoBehaviour
{
    [SerializeField] private GameObject Bod;
 


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "biteable")
        {
          
            print("yes");
            var newHinge = gameObject.AddComponent<HingeJoint2D>(); //make the new joint component
            newHinge.connectedBody = other.rigidbody; //connect it to the object we collided with
            // var contactPosition = other.contacts[0].point; //get world position of first contact
            var contactPosition = other.contacts[0].point; //get world position of first contact
            newHinge.anchor = transform.InverseTransformPoint(contactPosition); //convert world to local space and use it to set the anchor
                                                                                //newHinge.enableCollision = true; //enable the connected objects to collide (if you want)
            newHinge.autoConfigureConnectedAnchor = false;
            gameObject.transform.parent = Bod.transform;
            
        }
    }

}

    /*
{   [SerializeField] private GameObject chompZone;
   // [SerializeField] private Collider2D otherCollider;

    public void Start()
    {
       // otherCollider = chompZone.GetComponent<Collider2D>();
    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "biteable")
        {
            print("yas");
            HingeJoint2D hinge = col.GetComponent<HingeJoint2D>();
            hinge.enabled = true;

            /*var newHinge = gameObject.AddComponent<HingeJoint2D>(); //make the new joint component
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            newHinge.connectedBody = rb; //connect it to the object we collided with
            var contactPosition = col.contacts[0].point; //get world position of first contact
            newHinge.anchor = transform.InverseTransformPoint(contactPosition); //convert world to local space and use it to set the anchor
            newHinge.enableCollision = true; //enable the connected objects to collide (if you want)*/
    /* }
 }

    public void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.collider.tag == "biteable"){
            print("yes");
            var newHinge = gameObject.AddComponent<HingeJoint2D>(); //make the new joint component
            newHinge.connectedBody = other.rigidbody; //connect it to the object we collided with
            var contactPosition = other.contacts[0].point; //get world position of first contact
            newHinge.anchor = transform.InverseTransformPoint(contactPosition); //convert world to local space and use it to set the anchor
            //newHinge.enableCollision = true; //enable the connected objects to collide (if you want)
        }
        
        
        // creates joint
        
        if (col.collider.tag == "biteable")
        {
            print("yes");
            HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
            // sets joint position to point of contact
            joint.anchor = col.contacts[0].point;
            // conects the joint to the other object
            joint.connectedBody = col.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody2D>();
            // Stops objects from continuing to collide and creating more joints
            joint.enableCollision = false;
        }
        
        
    }
}
*/