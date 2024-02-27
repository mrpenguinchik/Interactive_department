using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPUIKIT;
using DG.Tweening;
public class MouseTutorial : MonoBehaviour
{
 [SerializeField]   MPImage mouse1;
 [SerializeField] MPImage mouse2;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject player3;
    // Start is called before the first frame update
    public void Init()
    {
        StartCoroutine(guide1()); 
        StartCoroutine(guide2());
    }
    IEnumerator guide1() {
        while (true)
        {
            mouse1.transform.DOLocalMoveX(30, 2);
            player1.transform.DORotate(new Vector3(0, 0, -30), 2);
            player3.transform.DORotate(new Vector3(0, 0, -30), 2);
            yield return new WaitForSeconds(2f);
            player1.transform.DORotate(new Vector3(0, 0, 30), 2);
            player3.transform.DORotate(new Vector3(0, 0, 30), 2);
            mouse1.transform.DOLocalMoveX(-30, 2);
            yield return new WaitForSeconds(2f);
        }
    }
    IEnumerator guide2() {
        while (true)
        {
            mouse2.transform.DOLocalMoveY(30, 2);
            player2.transform.DORotate(new Vector3(0, 0, -30), 2);
            yield return new WaitForSeconds(2f);
            player2.transform.DORotate(new Vector3(0, 0, 30), 2);
            mouse2.transform.DOLocalMoveY(-30, 2);
            yield return new WaitForSeconds(2f);
        }
    }
}

