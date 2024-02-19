using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Teacher", menuName = "ScriptableObjects/Teacher", order = 1)]
public class Teacher : ScriptableObject
{
    [SerializeField] public Sprite sprite;
    [SerializeField] public string FIO;
    [SerializeField] public string Doljnost;
    [SerializeField] public string Ovrzovanie;
    [SerializeField] public string Uch_step;
    [SerializeField] public string Uch_zvan;
    [SerializeField] public string Ped_staj;
    [SerializeField] public string Obj_staj;
    //Не менять в коде
}