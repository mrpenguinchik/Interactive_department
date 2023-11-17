using Prickly.UI.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestWindow : Window
{
    [SerializeField] WrongRightScreen _wr;
    [SerializeField] Test[] Logic;
    [SerializeField] TestZone zone;
    int Task=0;
    [SerializeField] private Button _button;

    public override void Init()
    {
        NextTask();
    }

    public void NextTask()
    {
        if (Task < Logic.Length)
        {
            Logic[Task].StartTask();
           _button.onClick.RemoveAllListeners();
           _button.onClick.AddListener(Logic[Task].SubmitOrder);
            Task++;
    }
        else
        {
            zone.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    public void WrongRight(bool Right)
    {
        if (Right)
        {
            _wr.ShowRight();
        }
        else
        {
            _wr.ShowWrong();
        }
    }
}
