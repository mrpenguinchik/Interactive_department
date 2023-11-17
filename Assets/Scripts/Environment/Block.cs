using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Block : MonoBehaviour
{
    [SerializeField] private VisualScriptingTask _vs;
   [SerializeField] private int _numberOfBlock;
   public void Dropped(int index)
    {
        _vs.UpdateOrder(index, _numberOfBlock);
    }
}
