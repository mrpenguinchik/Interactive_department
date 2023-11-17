using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _valueCount;

    private Action OnTextChanged;

    private Data.Key _key;

    public void Init(Data.Key key, Action onTextChanged, int count)
    {
        _key = key;

        OnTextChanged = onTextChanged;

        Add(count);
    }

    public int GetValue()
    {
        return _valueCount;
    }

    public void Add(int count)
    {
        _valueCount += count;
        OnTextChanged.Invoke();
    }

    public bool CanPurchase(int price)
    {
        return price <= _valueCount;
    }
}