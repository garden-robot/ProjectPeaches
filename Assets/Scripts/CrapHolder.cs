using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrapHolder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*private void PeachesResponse()
    {   
        _clicked = false;
        _peachesAnimTimer -= Time.deltaTime;
        if(_peachesAnimTimer <= Time.deltaTime){
            _responseIndex = 0;
            if(_responseIndex < _peachesResponses.Length - 1)
            {
                _responseCharIndex = 0;
            } 
            if(_responseIndex < _peachesResponses.Length){
                if (_responseCharIndex < _peachesResponses[_responseIndex].Length) 
                {
                    _textTimer -= Time.unscaledDeltaTime;
                    while (_responseCharIndex < _peachesResponses[_responseIndex].Length && _textTimer <= 0) {
                        ++_responseCharIndex;
                        _textTimer += _delay;
                    }                    
                    _peachesText.text = _peachesResponses[_responseIndex].Substring(0, _responseCharIndex);
                } else {
                    _clicked = true;
                    _textTimer = _delay;
                }   
            }
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
