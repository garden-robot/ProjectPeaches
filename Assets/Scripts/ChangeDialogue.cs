using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue = null;
    [SerializeField] private string _neededTag;
    private bool _entered = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == _neededTag && _entered == false)
        {
            _dialogue.DialogueTrigger();
            _entered = true;
        }
    }
}
