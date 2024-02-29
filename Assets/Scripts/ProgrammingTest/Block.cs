using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Block : MonoBehaviour
{
    [SerializeField] private VisualScriptingTask _vs;
   [SerializeField] private int _numberOfBlock;
    [SerializeField] private TMPro.TMP_Text _textMeshPro;
public void SetData(VisualScriptingTask vs,int index,string data,int lenght)//like constructor but just updates prefab data
    {
        _vs = vs;
        _numberOfBlock = index;
        _textMeshPro.text = data;

        _textMeshPro.transform.localScale = new Vector3(1 / lenght, 1, 1);

    }
    public void Dropped(int index)
    {
       // _vs.UpdateOrder(index, _numberOfBlock);
    }
}
