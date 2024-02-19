using MPUIKIT;
using Prickly.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeachersUI : MonoBehaviour
{
  [SerializeField]  UIController cont;
    [SerializeField] TMP_Text FIO;
    [SerializeField] TMP_Text Doljnost;
    [SerializeField] TMP_Text Ovrzovanie;
    [SerializeField] TMP_Text Uch_step;
    [SerializeField] TMP_Text Uch_zvan;
    [SerializeField] TMP_Text Ped_staj;
    [SerializeField] TMP_Text Obj_staj;
    [SerializeField] MPImage photo;
public void Show(Teacher teacher,bool state)
    {
   
        if (state)
        {
            cont.Show(true);
            FIO.text = teacher.FIO;
            Doljnost.text = teacher.Doljnost;
            Ovrzovanie.text = teacher.Ovrzovanie;
            Uch_step.text = teacher.Uch_step;
            Uch_zvan.text = teacher.Uch_zvan;
            Ped_staj.text = teacher.Ped_staj;
            Obj_staj.text = teacher.Obj_staj;
            photo.sprite = teacher.sprite;
        }
        else
        {
            cont.Hide(false);
        }
    }
}
