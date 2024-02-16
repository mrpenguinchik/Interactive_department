using UnityEngine;

[CreateAssetMenu(fileName = "Teacher", menuName = "ScriptableObjects/Teacher", order = 1)]
public class Teacher : ScriptableObject
{
    [SerializeField] public Sprite sprite;
    [SerializeField] public string desc;
}