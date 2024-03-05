
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerVariant : MonoBehaviour
{
  
    bool _isRight;
    bool _isActive;
    [SerializeField] Toggle _toggle;
    [SerializeField] TMP_Text _text;
    public void Init(string answer,bool isRight)
    {
     _text.text= answer;
     _isRight = isRight;
    _toggle.onValueChanged.AddListener((bool x) => { _isActive = x; });
    }
    public bool IsRight()=> _isRight;
    public bool IsActive() => _isActive;

}
