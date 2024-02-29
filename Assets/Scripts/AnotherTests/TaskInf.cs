using Prickly.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskInf : Test
{
  [SerializeField]  int answer;
    [SerializeField] UIController uIController;
    [SerializeField] TestWindow infTest;
    [SerializeField] TestSO TestData;
    List<TeastAnswer> _teastAnswers;
    [SerializeField] GameObject _answerPrefab;
    List<AnswerVariant> _answerVariants = new List<AnswerVariant>() ;
    [SerializeField] TMP_Text desc;
    const float y = 140;
    const float x1 = 34;
    public void CheckAnswer()
    {
        bool IsRight=true;
        foreach(AnswerVariant variant in _answerVariants)
        {
            if (variant.IsActive())
            {
                if (!variant.IsRight())
                {
                    IsRight = false;
                    break;
                }
            }
        }
        if (IsRight)
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
    /*public void ValueChanged(bool x)
    {
        int var;
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
  
    }*/

    public override void StartTask()
    {
        _teastAnswers = TestData.GetTastAnswers();
        desc.text= TestData.GetDesc();
        CreateUI();
        uIController.Show(true);
    }
    private void CreateUI()
    {
       float y1 = y;
        GameObject x;
       foreach(TeastAnswer teastAnswer in _teastAnswers) {
            x = Instantiate(_answerPrefab,this.transform);
            x.GetComponent<RectTransform>().localPosition = new Vector3(x1, y1);
            y1 -= 140f;
            _answerVariants.Add(x.GetComponent<AnswerVariant>());
            _answerVariants.Last<AnswerVariant>().Init(teastAnswer.GetAnswer(),teastAnswer.IsRight());
        }
    }
    public override void SubmitOrder()
    {
        CheckAnswer();
    }
}
