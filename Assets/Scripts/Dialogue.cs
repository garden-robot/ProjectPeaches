using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
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
    [SerializeField] private bool _triggerOnEnter = false;
    [SerializeField] private bool _onlyPlayOnce = false;
    [SerializeField] private string _neededTag = "Leash";
    [SerializeField] private Animator _interactableAnim = null;
    [SerializeField] private GameObject _barrier = null;
    [SerializeField] private int _nextDialogueConvoNum = 0;
    [SerializeField] private GameObject _nextDialogueActive = null;

    private string[] _dialogue = null;

    //vars for triggering dialogue on trigger enter
    [SerializeField] private float _animCloseTime = 0.8f;
    private bool _enterTriggered = false;
    private float _animCloseTimer = 0.8f;

    [Header("Peaches Responses")]
    [SerializeField] private GameObject[] _peachesFaces = null;
    [SerializeField] private AudioClip _interactableClip = null;
    [SerializeField] private GameObject _idleFace = null;

    private AudioSource _audio = null;
    private int _convoIndex = 0;


    private int _charIndex = 0;
    private float _textTimer;
    private float _delay = 0.1f;
    private int _index = -1;
    private bool _clicked = false;
    private bool _entered = false;
    private bool _objectEntered = false;

    private float _animTimer = 10f;
    private bool _animDone = false;
    private bool _animStarted = false;
    
    

    void Awake()
    {
        if(GetComponent<AudioSource>() != null){
            _audio = GetComponent<AudioSource>();
        }
        if(_interactableClip){
            _audio.clip = _interactableClip;
        }
        _animTimer = _animTime;
        _animCloseTimer = _animCloseTime;
        _text.text = "";
        _dialogue = _dialogue0;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == _neededTag && _objectEntered == false){
            DialogueTrigger();
            if(_barrier)
            {
                _barrier.SetActive(false);
            }
            _objectEntered = true;
        }

        //if player enters, set dialogue to start
        if(col.gameObject.tag == "Player")
        {
            if(_triggerOnEnter == true){
                _enterTriggered = true;
            }
            _entered = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //if player exits trigger area, reset conversation
        if(col.gameObject.tag == "Player")
        {
            _boxAnim.SetBool("Talked", false);
            if(_interactableAnim){
                _interactableAnim.SetBool("Talking", false);
            }
            _text.text = "";
            if(_triggerOnEnter == true){
                _enterTriggered = false;
            }
            _animTimer = _animTime;
            _animDone = false;
            _entered = false;
        }
    }
    
    public void DialogueTrigger()
    {
        //run this function to make function move forward
        if(_dialogue == _dialogue0){
            _dialogue = _dialogue1;
            _convoIndex++;
        }else if(_dialogue == _dialogue1){
            _dialogue = _dialogue2;
            _convoIndex++;
        }else if(_dialogue == _dialogue2){
            _dialogue = _dialogue3;
            _convoIndex++;
        }else if(_dialogue == _dialogue3){
            _dialogue = _dialogue4;
            _convoIndex++;
        }else{
            _dialogue = _dialogue5;
            _convoIndex = 5;
        }
    }

    private void DialogueExtras(){
        if(_interactableClip){
            _audio.Play();
        }
        if(_peachesFaces.Length > 0){
            if(_index <= _peachesFaces.Length +1 &&_peachesFaces[_index])
            {
                if(_idleFace){
                    if(_idleFace.activeSelf == true){
                    _idleFace.SetActive(false);
                }
            }
             if(_index-1 >= 0){
                _peachesFaces[_index -1].SetActive(false);
            }
            _peachesFaces[_index ].SetActive(true);
            //print(_index);
            }
        }
    }

    void Update()
    {
        //start dialogue on enter or if get key down
        if((_enterTriggered == true || Input.GetKeyDown("e")) && _entered == true && _animDone == false){
            _text.text = "";
            _boxAnim.SetBool("Talked", true);
            
            if(_interactableAnim){
                _interactableAnim.SetBool("Talking", true);
            }
            _animStarted = true;
        }

        //contine dialogue on dialogue key down if dialogue started 
        if(_animDone == true && Input.GetKeyDown("e"))
        {
            if (_charIndex < _dialogue[_index].Length) {
                _charIndex = _dialogue[_index].Length;
                _text.text = _dialogue[_index];
            }else{
                if(_index < _dialogue.Length - 1)
                {
                    _clicked = true;
                    _charIndex = 0;
                    DialogueExtras();
                    _index++;
                }else{
                    _boxAnim.SetBool("Talked", false);
                    if(_interactableAnim){
                        _interactableAnim.SetBool("Talking", false);
                    }
                    _animTimer = _animTime;
                    if(_triggerOnEnter == true){
                        _enterTriggered = false;
                        _animCloseTimer = _animCloseTime;
                    }
                    _text.text = "";
                    if(_idleFace){
                        if(_idleFace.activeSelf == false){
                            _idleFace.SetActive(true);
                        }
                    }
                    if(_index-1 >= 0 && _index-1 <= _peachesFaces.Length -1){
                        if(_peachesFaces[_index-1]){
                            _peachesFaces[_index-1].SetActive(false);
                        }
                    }
                    if(_nextDialogueConvoNum == _convoIndex){
                        if(_nextDialogueActive){
                            _nextDialogueActive.SetActive(true);
                            if(_onlyPlayOnce == true){
                                this.enabled = false;
                            }
                        }
                    }
                    _animDone = false;
                }  
            } 
        } 

        //check if player still in trigger zone and pressed E
        if(_boxAnim.GetBool("Talked") == false && _entered == true && _triggerOnEnter == true && _enterTriggered == false){
            _animCloseTimer -= Time.deltaTime;
            if(Input.GetKeyDown("e") && _animCloseTimer <= 0f){
                _enterTriggered = true;
            }
        }


        //check when animation is done to start first dialogue
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
                DialogueExtras();
                _animStarted = false;
            }
        }

        //dialogue running
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

        //peaches dialogue running
        
    }
}
