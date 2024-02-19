using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teachers : MonoBehaviour,ITeacher
{ 
    [SerializeField] Teacher teacher;

    public void ShowTeacher(bool state)
    {
        NewViewPort._viewPort.Show_teachers(teacher,state);
    }
}
public interface ITeacher
{
    public void ShowTeacher(bool state);
    
    
}