using Prickly.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class VisualScriptingTask :Test
{ [SerializeField] UIController ui;
    [SerializeField] TestWindow _logic;
    [SerializeField] ProgTaskSO TestData;
    [SerializeField] GameObject DefPrefab;
    [SerializeField] GameObject BlockPrefab;
    [SerializeField] GameObject SlotPrefab;

    public UIController UI => ui;
    List<ItemSlot> SlotList = new List<ItemSlot>();
    List<Answer> Answers;
   const float x1=-600;
    const float x2 = 0;
    const float  ys= 250;
    int[] Order;
    public override void StartTask()
    {
        Answers = TestData.GetAnswers();
        GenerateUI();
        ui.Show(true);
    }

    private void GenerateUI()
    {
        float y1 = ys, y2 = ys;
        GameObject x;
        RectTransform currentBlock;
        foreach (Answer answer in Answers)
        {
            if (!(answer.IsDef() || answer.IsWrong()))
            {
                x = Instantiate(SlotPrefab,this.transform);
                currentBlock = x.GetComponent<RectTransform>();

                currentBlock.localPosition = new Vector2(x1, y1);
                currentBlock.localScale = new Vector3( answer.GetLenght() * 1f,1,1);
              
                y1 -= 70f;
                SlotList.Add(x.GetComponent<ItemSlot>());
                SlotList.Last<ItemSlot>().SetIndex(SlotList.Count);
            }
            if (!answer.IsWrong())
            {
                if (answer.IsDef())
                {
                    x = Instantiate(DefPrefab, this.transform);
                    currentBlock = x.GetComponent<RectTransform>();
                    currentBlock.localPosition = new Vector2(x1, y1);
                    currentBlock.localScale = new Vector3(answer.GetLenght() * 1f, 1, 1);
                    y1 -= 70f;
                    x.GetComponent<Def>().SetText(answer.GetData(), answer.GetLenght());
                }
                else
                {
                    x = Instantiate(BlockPrefab, this.transform);
                    currentBlock = x.GetComponent<RectTransform>();
                    currentBlock.localPosition = new Vector2(x2, y2);
                    currentBlock.localScale = new Vector3(answer.GetLenght() * 1f, 1, 1);
                    y2 -= 70f;
                    x.GetComponent<Block>().SetData(this, answer.GetPos(), answer.GetData(), answer.GetLenght());
                }

            }
        }
    }
    public void CreateOrder()
    {
        Order = new int[SlotList.Count];
        for (int i = 0; i < SlotList.Count; i++)
        {
            Order[i] = 0;
        }
    }
    public void UpdateOrder(int index, int blcoknumber)
    {
        Order[index] = blcoknumber;
    }

    public override void SubmitOrder()
    {
        bool IsRight = true;
     for(int i = 0; i < Answers.Count; i++)
        {
           
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
