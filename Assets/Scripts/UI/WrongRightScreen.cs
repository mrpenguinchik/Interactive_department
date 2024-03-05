using Prickly.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongRightScreen : MonoBehaviour
{
    [SerializeField] UIController _screen;
    [SerializeField] List<TestTaskFInished> _view;
    [SerializeField] Image _image;
    [SerializeField] TMPro.TMP_Text _text;
   public void ShowWrong()
    { 
        StartCoroutine(Show(0));
    }
    IEnumerator Show(int viewId)
    {
        _image.sprite = _view[viewId].Image;
        _text.text = _view[viewId].Text;
        _text.color = _view[viewId].Color;
      _screen.Show(true);
        yield return new WaitForSeconds(2f);
        _screen.Hide(true);
    }
    public void ShowRight()
    {
        StartCoroutine(Show(1));
    }
   
}
