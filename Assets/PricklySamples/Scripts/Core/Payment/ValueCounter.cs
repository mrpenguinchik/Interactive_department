using System;
using NaughtyAttributes;
using UnityEngine;
using Prickly.Core;
    
public class ValueCounter: InGameObject, IInitializable
{
    public static ValueCounter Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private WalletType[] _walletTypes;

    [Header("Debug")]
    [SerializeField] private Transaction _transaction;

    public void Init()
    {
        for (int i = 0; i < _walletTypes.Length; i++)
        {
            _walletTypes[i].Init();
        }
    }

    public void Add(Money money, int cost)
    {
        for (int i = 0; i < _walletTypes.Length; i++)
        {
            if (_walletTypes[i].Key.SaveName == money.Key.SaveName)
            {
                _walletTypes[i].Add(cost);
            }
        }
    }

    public void Remove(Transaction transaction)
    {
        for (int i = 0; i < _walletTypes.Length; i++)
        {
            if (_walletTypes[i].Key.SaveName == transaction.Money.Key.SaveName)
            {
                _walletTypes[i].Remove(transaction.Cost);
            }
        }
    }

    public void Save()
    {
        foreach (WalletType walletType in _walletTypes)
        {
            walletType.Save();
        }
    }

    public int GetValue(Money money)
    {
        for (int i = 0; i < _walletTypes.Length; i++)
        {
            if (_walletTypes[i].Key.SaveName == money.Key.SaveName)
            {
                return _walletTypes[i].Value;
            }
        }

        return 0;
    }

    [Button]
    private void AddDebug()
    {
        print("Add");
        Add(_transaction.Money, _transaction.Cost);
    }

    [Serializable]
    public struct WalletType : IInitializable
    {
        public int Value;
        public Data.Key Key => _money.Key;

        [SerializeField] int DefaultValue;
        [SerializeField] private WalletView[] WalletViews;
        [SerializeField] private Money _money;

        public void Init()
        {
            Load();
            foreach (WalletView walletView in WalletViews)
            {
                walletView.Init(this, _money.Sprite);
            }
        }

        public void Add(int count)
        {
            if (count < 0) count = 0;

            Value += count;
            foreach (WalletView walletView in WalletViews)
            {
                walletView.Add(count);
            }
        }

        public void Remove(int count)
        {
            if (count < 0) count = 0;

            Value -= count;
            foreach (WalletView walletView in WalletViews)
            {
                walletView.Add(-count);
            }
        }

        public void Save()
        {
            DataProvider.SaveByKey(Key, Value);
        }

        private void Load()
        {
            DataProvider.LoadByKey(Key, out Value, DefaultValue);
        }
    }
}
