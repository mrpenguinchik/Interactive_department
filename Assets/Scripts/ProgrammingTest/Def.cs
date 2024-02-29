using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Def:MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text _textMeshPro;
    public void SetText(string text,int length)
    {
        _textMeshPro.text = text;
     
        _textMeshPro.transform.localScale = new Vector3(1 / length, 1, 1);
    }
}
