using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private string[] _dialogue = null;

    private Text _text = null;
    private int _charIndex = 0;
    private float _textTimer;
    private float _delay = 0.1f;
    private int _index = -1;
    private bool _clicked = false;

    void Awake()
    {
        _text = GetComponent<Text>();
    }
    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            _clicked = true;
            _charIndex = 0;
            if(_index < _dialogue.Length - 1)
            {
                _index++;
            }else{
                _index = 0;
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
                    //
                    _textTimer = _delay;
                }   
            }else{
                _clicked = false;
            }
        }
    }
}
