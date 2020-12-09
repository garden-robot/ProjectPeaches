using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEnding : MonoBehaviour
{
    [SerializeField] private string _neededTag = "Leash";
    [SerializeField] private Animator _ending = null;
    [SerializeField] private GameObject _healthBar = null;
    [SerializeField] private GameObject _dialogueCanvas = null;
    private bool _ended = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Leash" && _ended == false)
        {
            _ending.SetTrigger("end");
            _healthBar.SetActive(false);
            _dialogueCanvas.SetActive(false);
            _ended = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
