using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cameramov : MonoBehaviour
{
    // public Transform cameraObject;
    public Transform background;
    public Vector3 cameraOffset;
    public Image blackScreen;
    public int time = 3;

    public GameObject nextRoom;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {   
            Camera.main.transform.position = background.position + cameraOffset;
            if(nextRoom != null)
            {
                nextRoom.SetActive(false);
               // gameObject.SetActive(false);
            }
        

            FadeToBlack();
            FadeFromBlack();
        }
    }
    
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
          

            if (nextRoom != null)
            {
                nextRoom.SetActive(true);
               gameObject.SetActive(false);
            }
        }
    }
    

    void FadeToBlack()
    {
        blackScreen.color = Color.black;
        blackScreen.canvasRenderer.SetAlpha(0.0f);
        blackScreen.CrossFadeAlpha(1.0f, time, false);
    }

    void FadeFromBlack()
    {
        blackScreen.color = Color.black;
        blackScreen.canvasRenderer.SetAlpha(1.0f);
        blackScreen.CrossFadeAlpha(0.0f, time, false);
    }
}
