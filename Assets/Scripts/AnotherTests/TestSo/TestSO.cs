using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Test", menuName = "ScriptableObjects/Test", order = 1)]
public class TestSO :ScriptableObject
{
    [SerializeField] private string _desc;
    [SerializeField] private List<TeastAnswer> _teastAnswers = new List<TeastAnswer>();
    public List<TeastAnswer> GetTastAnswers() => _teastAnswers;
    public string GetDesc() => _desc;
}
