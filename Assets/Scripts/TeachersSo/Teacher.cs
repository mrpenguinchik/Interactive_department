using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Teacher", menuName = "ScriptableObjects/Teacher", order = 1)]
public class Teacher : ScriptableObject
{
    [SerializeField] public Sprite sprite;
    [SerializeField] public string FIO;
    [SerializeField] public string Doljnost= "Должность:";
    [SerializeField] public string Qualification = "Квалификация:";
    [SerializeField] public string Ovrzovanie= "Образование:";
    [SerializeField] public string Uch_step= "Ученая степень:";
    [SerializeField] public string Uch_zvan= "Ученое звание:";
    [SerializeField] public string Ped_staj= "Педагогический стаж (лет):";
    [SerializeField] public string Obj_staj= "Общий стаж работы (лет):";
    [SerializeField] public string Disc= "Преподаваемые дисциплины:";
    //Не менять в коде
}