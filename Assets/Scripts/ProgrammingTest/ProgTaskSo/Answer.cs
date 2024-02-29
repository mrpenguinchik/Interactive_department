using System;
using NaughtyAttributes;
using UnityEngine;


[Serializable]
public class Answer
{
    [SerializeField] private bool _isDef;
    [SerializeField]
    private string _answer;
    [SerializeField] private int pos;
    public int GetPos() => pos;
    public string GetData() => _answer;
    public bool IsDef() => _isDef;
 [Button]
    private void autoChangeLenght()
    {
        _lenght=_answer.Length;
    }
    [SerializeField] private int _lenght;
    [SerializeField] private bool _isWrong;
    public int GetLenght() => _lenght;
    public bool IsWrong() => _isWrong;
}
