using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroDialogue : MonoBehaviour
{
    [SerializeField] private string[] _dialogue = null;
    [SerializeField] private Animator _open = null;
    [SerializeField] private float _animTime = 10f;

    private Text _text = null;
    private int _charIndex = 0;
    private float _textTimer;
    private float _delay = 0.1f;
    private int _index = 0;
    private bool _clicked = false;
    private float _animTimer = 10f;
    private bool _animStart = false;

    
    void Start()
    {
         _text = GetComponent<Text>();
         _animTimer = _animTime;
    }

    // Update is called once per frame

    public void StartDialogue()
    {
        _open.SetTrigger("Talked");
        _animStart = true;
        //_clicked = true;
        //_charIndex = 0;
        
        /*if(_index < _dialogue.Length - 1)
        {
            _index++;
        }else{
            _index = 0;
        }*/
    }
    void Update()
    {
        if(_animStart == true)
        {
            _animTimer -= Time.deltaTime;
            print(_animTimer);
            if(_animTimer <= 0f){
                if(_index < _dialogue.Length){
                    if (_charIndex < _dialogue[_index].Length) {
                        _textTimer -= Time.unscaledDeltaTime;
                        while (_charIndex < _dialogue[_index].Length && _textTimer <= 0) {
                            ++_charIndex;
                            _textTimer += _delay;
                        }                    
                        _text.text = _dialogue[_index].Substring(0, _charIndex);
                    } else {
                        //
                        _textTimer = _delay;
                    }   
                }else{
                    _clicked = false;
                }
            }
        }
    }
}
