using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayer : Interactable<ITeacher>
{ 
    protected override void OnInteract(ITeacher obj)
    {
        if (Input.GetKey(KeyCode.E))
        {
            obj.ShowTeacher();
        }
    }
}
