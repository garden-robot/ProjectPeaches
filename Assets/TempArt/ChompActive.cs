using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChompActive : MonoBehaviour
{
    [SerializeField] private GameObject _chompZone = null;
    [SerializeField] private Transform _pickUpObject = null;
    [SerializeField] private ChompCollision _chompCollider;
    public Animation anim;
    private Transform _jaw = null;

    void Awake()
    {
        _chompZone.SetActive(false);
        _jaw = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(_jaw.localRotation.z >= 0f && _jaw.localRotation.z <= 1f)
        if (Input.GetMouseButton(0))
        {
            _chompZone.SetActive(true);
            anim.enabled = true;
            anim.Play("Jaw open");

        }
        else{
           
                _chompZone.SetActive(false);
            }



        if (_chompZone.activeInHierarchy)
        {
            _pickUpObject = this.gameObject.transform.GetChild(transform.childCount - 1);

            if (_pickUpObject.tag == "pickUp")
            {
                anim.enabled = false;
            }
        }
        else
        {
            if(_pickUpObject != null && _pickUpObject.tag == "pickUp")
            {
                _pickUpObject.parent = null;
                var joint =  _pickUpObject.gameObject.GetComponent<HingeJoint2D>();
                Destroy(joint);
            }
        }


    }



}
