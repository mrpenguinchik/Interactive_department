using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ProgTask", menuName = "ScriptableObjects/ProgTask", order = 1)]
public class ProgTaskSO :ScriptableObject
{
[SerializeField] private List<Answer> _answerList;
    public List<Answer> GetAnswers() => _answerList;
}


