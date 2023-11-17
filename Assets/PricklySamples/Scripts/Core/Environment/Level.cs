using UnityEngine;
using Prickly.Core;

public abstract class Level : InGameObject, IInitializable
{
    public virtual UpgradeZone UpgradeZone { get; }

    [SerializeField] protected Base Base;

    public abstract void Init();
    public abstract void Lock();
    public abstract void Unlock();
}
