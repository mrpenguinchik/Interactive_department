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
   [SerializeField]  private bool _isRight;

    public bool IsRight() => _isRight;
    private bool _canBeRight;
    public void SetData(VisualScriptingTask vs,int index,string data,int lenght,bool wrong)//like constructor but just updates prefab data
    {
        _vs = vs;
        _numberOfBlock = index;
        _textMeshPro.text = data;
        _canBeRight = wrong;
        _isRight = wrong;
        _textMeshPro.transform.localScale = new Vector3(1f / lenght, 1, 1);

    }
    public void Dropped(int index)
    {
        _isRight = (_numberOfBlock==index)||_canBeRight;
     
    }
}
