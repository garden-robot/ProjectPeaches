using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BeginButton : MonoBehaviour
{
    [SerializeField] private Text _text = null;
    [SerializeField] private Vector2 _unHoverSize = Vector2.one;
    [SerializeField] private Vector2 _hoverSize = Vector2.zero;
    [SerializeField] private Vector2 _clickSize = Vector2.zero;
    [SerializeField] private Color _textHoverColor = Color.white;
    [SerializeField] private Color _textUnhoverColor = Color.white;

    private RectTransform _button = null;   
    void Awake()
    {
        _unHoverSize = _button.localScale;
    }

    // Update is called once per frame
    void OnPointerEnter()
    {
        _button.localScale = _hoverSize;
        _text.color = _textHoverColor;
    }
}
