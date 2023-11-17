using Prickly.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskInf : Test
{
  [SerializeField]  int answer;
    [SerializeField] UIController uIController;
    [SerializeField] TestWindow infTest;
    int var;
   [SerializeField] Toggle[] Toggles;
    public void CheckAnswer()
    {
        if (var == answer)
        {
            infTest.WrongRight(true);
            infTest.NextTask();
            uIController.Hide(false);
        }
        else
        {
            infTest.WrongRight(false);
        }
    }
    public void ValueChanged()
    {
       int j = -1;
        for (int i = 0; i < Toggles.Length; i++)
        {
            if (Toggles[i].isOn)
            {
                j = i;
            }
        }
        var = j+1;
        if (j == -1)
        {
            for (int i = 0; i < Toggles.Length; i++)
            {
                if (Toggles[i].interactable)
                {
                    j = i;
                }
            }
        }
        for(int i = 0;i< Toggles.Length; i++)
        {
            if (j!=i)
            {
                Toggles[i].interactable=(!Toggles[j].isOn);
            }
        }
  
    }

    public override void StartTask()
    {
        uIController.Show(true);
    }

    public override void SubmitOrder()
    {
        CheckAnswer();
    }
}
