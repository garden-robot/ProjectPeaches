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

    private RectTransform _button = null;
    private bool _deselected = false;
    private float _buttonWait = .05f;


    void Awake()
    {
        _button = GetComponent<RectTransform>();
        _unHoverSize = _button.localScale;
        _textUnhoverSize = _text.fontSize;
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
    }

        public void CreditsOnClick()
    {
        _text.fontSize = _textClickSize;
        _button.localScale = _clickSize;
    }

        public void QuitOnClick()
    {
        _text.fontSize = _textClickSize;
        _button.localScale = _clickSize;
    }

    private void Update()
    {

    }
}
