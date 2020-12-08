using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueAutomated : MonoBehaviour
{
    [SerializeField] private Animator _boxAnim = null;
    [SerializeField] private Text _text = null;
    [SerializeField] private float _animTime = 0.6f;
    [SerializeField] private string[] _dialogue = null;
    private float _animTimer = 0.6f;
    private bool _entered = false;
    private bool _animStarted = false;
    private bool _animDone = false;
    private bool _clicked = false;

    private int _index = 0;
    private int _charIndex = 0;

    private float _textTimer = 0.1f;
    private float _delay = 0.1f;

    [SerializeField] private float _restartTime = 3f;
    private float _restartTimer = 3f;
 

    void Awake()
    {
        _animTimer = _animTime;
        _restartTimer = _restartTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            _entered = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            _entered = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_entered == true && _animDone == false){
            _text.text = "";
            _boxAnim.SetBool("Talked", true);
            _animStarted = true;
        }

        if(_animStarted == true)
        {
            _animTimer -= Time.deltaTime;
            if(_animTimer <= Time.deltaTime){
                _index = 0;
                _animDone = true;
                if(_index < _dialogue.Length - 1)
                {
                    _clicked = true;
                    _charIndex = 0;
                } 
                _animStarted = false;
            }
        }

        if(_clicked == true){
            if(_index < _dialogue.Length){
                if (_charIndex < _dialogue[_index].Length) {
                    _textTimer -= Time.unscaledDeltaTime;
                    while (_charIndex < _dialogue[_index].Length && _textTimer <= 0) {
                        ++_charIndex;
                        _textTimer += _delay;
                    }                    
                    _text.text = _dialogue[_index].Substring(0, _charIndex);
                } else {
                    _textTimer = _delay;
                    _restartTimer -= Time.deltaTime;
                    print(_restartTimer);
                    if(_restartTimer <= 0f){
                        _charIndex = 0;
                        _index++;
                        _restartTimer = _restartTime;
                    }
                }   
            }
        }

    }



}
