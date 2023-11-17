using UnityEngine;
using Prickly.Core;
using static ValueCounter;
using Prickly.UI;

[RequireComponent(typeof(Wallet))]
public class WalletView : InGameObject, IInitializable<WalletType, Sprite>
{
    [SerializeField] private Counter _counter;
    [SerializeField] private Wallet _wallet;

    public void Init(WalletType walletType, Sprite sprite)
    {
        _wallet.Init(walletType.Key, ChangeText, walletType.Value);
        _counter.Init(sprite);
    }

    public void Add(int count)
    {
        _wallet.Add(count);
    }

    private void ChangeText()
    {
        _counter.SetText(_wallet.GetValue().ToString());
    }
}