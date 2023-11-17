using System;
using UnityEngine;

public class Payment
{
    private ValueCounter ValueCounter
    {
        get
        {
            if (_valueCounter == null)
                _valueCounter = ValueCounter.Instance;

            return _valueCounter;
        }
    }

    private ValueCounter _valueCounter;

    public bool CanPurchase(Transaction transaction) => ValueCounter.GetValue(transaction.Money) >= transaction.Cost;
    
    public void OnPurchase(Transaction transaction, Action action)
    {
        ValueCounter.Remove(transaction);
        action?.Invoke();
    }
}

[Serializable]
public class Transaction
{
    [SerializeField] private Money _money;
    [SerializeField] private int _cost;

    public Money Money => _money;
    public int Cost => _cost;

    public Transaction(Money money, int cost)
    {
        _money = money;
        _cost = cost;
    }

    public void Add()
    {
        _cost++;
    }

    public void Remove()
    {
        _cost--;
    }
}
