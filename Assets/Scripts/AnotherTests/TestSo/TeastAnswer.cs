using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class TeastAnswer 
{
    [SerializeField] private string answer;
    [SerializeField] private bool isRight=false;
    public string GetAnswer() => answer;
    public bool IsRight() => isRight;
}
