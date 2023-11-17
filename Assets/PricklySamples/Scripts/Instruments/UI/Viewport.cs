using UnityEngine;
using Prickly.Core;
using Prickly.UI.Windows;

public class Viewport : InGameObject, IInitializable
{
    [SerializeField] private InGame _inGame;
    [SerializeField] private Upgrade _upgrade;

    public Upgrade Upgrade => _upgrade;

   virtual public void Init()
    {
        _upgrade.Init();
        _upgrade.Hide(false);
    }
}
