using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureInRoom : MonoBehaviour
{[SerializeField] private string RoomTag;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (RoomTag == col.GetComponent<Collider2D>().tag) {
            Debug.Log("Entered");
                }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (RoomTag == col.GetComponent<Collider2D>().tag)
        {
            Debug.Log("Exit");
        }
    }
}
