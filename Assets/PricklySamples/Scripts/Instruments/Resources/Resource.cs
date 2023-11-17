using UnityEngine;

public abstract class Resource : ScriptableObject, IData
{
    public abstract Data.Key Key { get; }
    public abstract Sprite Sprite { get; }
}
