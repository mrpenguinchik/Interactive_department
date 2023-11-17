using Prickly.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongRightScreen : MonoBehaviour
{
    [SerializeField] UIController wrong, right;
   public void ShowWrong()
    {
        StartCoroutine(Wrong());
    }
    IEnumerator Wrong()
    {
        wrong.Show(true);
        yield return new WaitForSeconds(2f);
        wrong.Hide(true);
    }
    public void ShowRight()
    {
        StartCoroutine(Right());
    }
    IEnumerator Right()
    {
        right.Show(true);
        yield return new WaitForSeconds(2f);
        right.Hide(true);
    }
}
