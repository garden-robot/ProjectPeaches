using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepFurnitureIn : MonoBehaviour
{
    void Awake()
    {
        Physics2D.IgnoreLayerCollision(5,11);
    }
}