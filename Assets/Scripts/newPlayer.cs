using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class newPlayer : Interactable<ITeacher>
{ 
    bool KeyState=false;
    Coroutine cor=null;
    protected override void OnInteract(ITeacher obj)
    {
      
        this.OnEndInteract = () => { if (cor != null) { StopCoroutine(cor); } cor = null; KeyState = false; obj.ShowTeacher(false); };
        if (cor == null)
        {
            cor = StartCoroutine(input(obj));
        }

    }
    public IEnumerator input(ITeacher obj)
    {

        yield return new WaitUntil(()=>Input.GetKey(KeyCode.E));
        KeyState = !KeyState;
        obj.ShowTeacher(KeyState);
        yield return new WaitForSeconds(1);
        cor = null;
        
    }
    
}
