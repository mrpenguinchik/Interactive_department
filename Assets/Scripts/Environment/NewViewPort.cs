using Prickly.UI.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewViewPort : Viewport
{
    public static NewViewPort _viewPort=null;
 [SerializeField]   TeachersUI teachersUI;
    override public void Init()
    {
        _viewPort = this;
    }
     public void Show_teachers(Teacher teacher,bool state)
    {
        teachersUI.Show(teacher,state);
    }
}
