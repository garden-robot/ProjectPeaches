using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    [SerializeField] private Text _text = null;
    [SerializeField] private Vector2 _unHoverSize = Vector2.one;
    [SerializeField] private Vector2 _hoverSize = Vector2.zero;
    [SerializeField] private Vector2 _clickSize = Vector2.zero;
    [SerializeField] private Color _textHoverColor = Color.white;
    [SerializeField] private Color _textUnhoverColor = Color.blue;
    [SerializeField] private int _textUnhoverSize = 20;
    [SerializeField] private int _textHoverSize = 36;  
    [SerializeField] private int _textClickSize = 40;  
    [SerializeField] private float _buttonWaitTime = .05f;

    //BeginButton
    [SerializeField] private Animator _cameraAnim = null;
    //[SerializeField] private float _camScaleTime = 5f;
    //[SerializeField] private IntroDialogue _introDialogue = null;
    [SerializeField] private GameObject _startBarrier = null;

    //CreditsScaling
    [SerializeField] private Animator _credits = null;
 
    //Fade out Buttons
    [SerializeField] private Animator[] _buttons = null;
    [SerializeField] private float _clickedTime = 0.2f;
    [SerializeField] private float _camOffTime = 1f;
    [SerializeField] private Animator _backButton = null;
    private float _clickedTimer = 1f;
    private bool _begun = false;
    private int _index = 0;
    private RectTransform _button = null;
    private bool _clicked = false;
    private bool _backClicked = false;
    private bool _creditsClicked = false;

    void Awake()
    {
        _button = GetComponent<RectTransform>();
        _unHoverSize = _button.localScale;
        _textUnhoverSize = _text.fontSize;
        _clickedTimer = _clickedTime;
    }

    // Update is called once per frame
    public void OnPointerEnter()
    {
        _button.localScale = _hoverSize;
        _text.color = _textHoverColor;
        _text.fontSize = _textHoverSize;
    }

    public void OnPointerExit()
    {
        _button.localScale = _unHoverSize;
        _text.color = _textUnhoverColor;
        _text.fontSize = _textUnhoverSize;
    }

    public void BeginOnClick()
    {
        _text.fontSize = _textClickSize;
        _button.localScale = _clickSize;
        _cameraAnim.SetTrigger("Clicked");
        //_introDialogue.StartDialogue();
        _startBarrier.SetActive(false);
        _begun = true;
        _clicked = true;
    }

        public void CreditsOnClick()
    {
        _text.fontSize = _textClickSize;
        _button.localScale = _clickSize;
        _creditsClicked = true;
        _credits.SetBool("Clicked", true);
        _clicked = true;

    }

    public void CreditsBackOnClick()
    {
        _text.fontSize = _textClickSize;
        _button.localScale = _clickSize;
        _credits.SetBool("Clicked", false);
        _backClicked = true;
    }

        public void QuitOnClick()
    {
        _text.fontSize = _textClickSize;
        _button.localScale = _clickSize;
        Application.Quit();
        _clicked = true;
    }

    private void Update()
    {
        if(_clicked == true)
        {
            if (_creditsClicked == true)
            {
                //_backButton.SetTrigger("Clicked");
            }

            if (_index < _buttons.Length)
            { 
                _clickedTimer -= Time.deltaTime;
                if(_clickedTimer<=0f)
                {
                    _buttons[_index].SetTrigger("Clicked");
                    _clickedTimer = _clickedTime;
                    _index++;
                }
            }else{
                _index = 0;
                _clicked = false;
            }
        }

        if(_backClicked == true)
        {
            _backButton.SetTrigger("UnClicked");
            if (_index < _buttons.Length)
            { 
                _clickedTimer -= Time.deltaTime;
                if(_clickedTimer<=0f)
                {
                    _buttons[_index].SetTrigger("Clicked");
                    _clickedTimer = _clickedTime;
                    _index++;
                }
            }else{
                _index = 0;
                _backClicked = false;
            }
        }

        if(_begun == true)
        {  
            _camOffTime -= Time.deltaTime;
            print(_camOffTime);
            if(_camOffTime <= 0f){
                _cameraAnim.enabled = false;
                
                _begun = false;
            }
        }
    }
}
