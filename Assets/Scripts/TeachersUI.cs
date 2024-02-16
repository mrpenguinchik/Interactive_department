using MPUIKIT;
using Prickly.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeachersUI : MonoBehaviour
{
  [SerializeField]  UIController cont;
    [SerializeField] TMP_Text text;
    [SerializeField] MPImage photo;
public void Show(Teacher teacher)
    {
        cont.Show(true);
        text.text = teacher.desc;
        photo.sprite = teacher.sprite;
    }
}
