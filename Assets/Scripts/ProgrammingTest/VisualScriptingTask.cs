using Prickly.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualScriptingTask :Test
{ [SerializeField] UIController ui;
    [SerializeField] TestWindow _logic;

    public UIController UI => ui;
    [SerializeField] int[] _Slots; 
    
 int[] Order;
    public override void StartTask()
    {
        CreateOrder();
        ui.Show(true);
    }
    public void CreateOrder()
    {
        Order = new int[_Slots.Length];
        for(int i=0; i<_Slots.Length; i++)
        {
            Order[i]=0;
        }
    }
    public void UpdateOrder(int index,int blcoknumber)
    { 
        Order[index] = blcoknumber;
    }
    
    public override void SubmitOrder()
    { 
       foreach(int x in Order)
        {
            print(x);
        }
        bool IsRight = true;
        for(int i=0; i<Order.Length; i++)
        {
            if (Order[i] != _Slots[i])
            {
                IsRight = false;
                break;
            }
        }
        if (IsRight)
        {
            _logic.WrongRight(true);
            _logic.NextTask();
            ui.Hide(false);
        }
        else
        {
            _logic.WrongRight(false);
        }
    }
}
