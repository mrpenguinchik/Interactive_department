using Prickly.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class VisualScriptingTask :Test
{ [SerializeField] UIController ui;
    [SerializeField] TestWindow _logic;
    [SerializeField] ProgTaskSO TestData;
    [SerializeField] GameObject DefPrefab;
    [SerializeField] GameObject BlockPrefab;
    [SerializeField] GameObject SlotPrefab;
    [SerializeField] private TMP_Text _descTMP;
    public UIController UI => ui;
    List<Block> BlockList = new List<Block>();
    List<Answer> Answers;
   const float x1=-600;
    const float x2 = 0;
    const float  ys= 250;
    public override void StartTask()
    {
        Answers =new List<Answer>( TestData.GetAnswers());
        _descTMP.text = TestData.GetDesc();
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
            currentBlock = null;
            if (!(answer.IsDef() || answer.IsWrong()))
            {
                x = Instantiate(SlotPrefab,this.transform);
                currentBlock = x.GetComponent<RectTransform>();

         
            x.GetComponent<ItemSlot>().SetIndex(answer.GetPos());
            }
        
                if (answer.IsDef())
                {
                    x = Instantiate(DefPrefab, this.transform);
                    currentBlock = x.GetComponent<RectTransform>();
            
                    x.GetComponent<Def>().SetText(answer.GetData(), answer.GetLenght());
                }
            if (currentBlock != null)
            {
                currentBlock.localPosition = new Vector2(x1+(answer.GetMargin()*50), y1);
                currentBlock.localScale = new Vector3(answer.GetLenght() * 1f, 1, 1);
                y1 -= 70f;
            }



        }
        Shuffle.Shuffles<Answer>(Answers);
     foreach(Answer answer in Answers)
        { if (answer.IsDef()) { continue; }
            x = Instantiate(BlockPrefab, this.transform);
            currentBlock = x.GetComponent<RectTransform>();
            currentBlock.localPosition = new Vector3(x2, y2);
            currentBlock.localScale = new Vector3(answer.GetLenght() * 1f, 1, 1);
            y2 -= 70f;
            BlockList.Add(x.GetComponent<Block>());
            BlockList.Last<Block>().SetData(this, answer.GetPos(), answer.GetData(), answer.GetLenght(), answer.IsWrong());
        }
    }

    public override void SubmitOrder()
    {
   
        bool IsRight = true;
        for (int i = 0; i < BlockList.Count; i++)
        {
            if (!BlockList[i].IsRight())
            {
                IsRight = false;
                break;
            }
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
