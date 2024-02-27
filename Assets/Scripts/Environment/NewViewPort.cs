using Prickly.UI.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewViewPort : Viewport
{
    public static NewViewPort _viewPort=null;
 [SerializeField]   TeachersUI teachersUI;
    [SerializeField] MouseTutorial mouse;
    override public void Init()
    {
        _viewPort = this;
        mouse.Init();
    }
     public void Show_teachers(Teacher teacher,bool state)
    {
        teachersUI.Show(teacher,state);
    }
}
