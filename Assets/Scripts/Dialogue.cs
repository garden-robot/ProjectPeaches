using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private string[] _dialogue0 = null;
    [SerializeField] private string[] _dialogue1 = null;
    [SerializeField] private string[] _dialogue2 = null;
    [SerializeField] private string[] _dialogue3 = null;
    [SerializeField] private string[] _dialogue4 = null;
    [SerializeField] private string[] _dialogue5 = null;
    [SerializeField] private Animator _boxAnim = null;
    [SerializeField] private float _animTime = 10f;
    [SerializeField] private Text _text = null;
    //[SerializeField] private bool _triggerOnEnter = false;

    private string[] _dialogue = null;
    //private int _dialogueIndex = 0;

    private int _charIndex = 0;
    private float _textTimer;
    private float _delay = 0.1f;
    private int _index = -1;
    private bool _clicked = false;
    private bool _entered = false;

    private float _animTimer = 10f;
    private bool _animDone = false;
    private bool _animStarted = false;

    void Awake()
    {
        _animTimer = _animTime;
        _text.text = "";
        _dialogue = _dialogue0;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            print("Ya");
            //DialogueTrigger();
            _entered = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            print("Nah");
            _boxAnim.SetBool("Talked", false);
            _text.text = "";
            _animTimer = _animTime;
            _animDone = false;
            _entered = false;
        }
    }
    
    public void DialogueTrigger()
    {
        //_dialogueIndex ++;
        if(_dialogue == _dialogue0){
            _dialogue = _dialogue1;
        }else if(_dialogue == _dialogue1){
            _dialogue = _dialogue2;
        }else if(_dialogue == _dialogue2){
            _dialogue = _dialogue3;
        }else if(_dialogue == _dialogue3){
            _dialogue = _dialogue4;
        }else{
            _dialogue = _dialogue5;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("e") && _entered == true)
            {
                if(_animDone == false)
                {
                    _text.text = "";
                    _boxAnim.SetBool("Talked", true);
                    _animStarted = true;
                }else{  
                    if(_index < _dialogue.Length - 1)
                    {
                        _clicked = true;
                        _charIndex = 0;
                        _index++;
                    }else{
                        _boxAnim.SetBool("Talked", false);
                        _text.text = "";
                        _animTimer = _animTime;
                        _animDone = false;
                    }   
                }
            }

        if(_animStarted == true)
        {
            _animTimer -= Time.deltaTime;
            if(_animTimer <= Time.deltaTime){
                _index = 0;
                _animDone = true;
                print("anim done"); 
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
                }   
            }
        }
    }
}
