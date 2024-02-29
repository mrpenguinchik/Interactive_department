using System;
using NaughtyAttributes;
using UnityEngine;


[Serializable]
public class Answer
{
    [SerializeField] private float _marginLeft;
    public float GetMargin()=>_marginLeft;
    [SerializeField] private bool _isDef;
    [SerializeField]
    private string _answer;
    [SerializeField] private int pos;
    public int GetPos() => pos;
    public string GetData() => _answer;
    public bool IsDef() => _isDef;

 
    [SerializeField] private int _lenght;
    [SerializeField] private bool _isWrong;
    public int GetLenght() => _lenght;
    public bool IsWrong() => _isWrong;
}
