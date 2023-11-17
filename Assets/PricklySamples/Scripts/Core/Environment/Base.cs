using Prickly.Core;

public abstract class Base : InGameObject, IInitializable
{
    public abstract void Init();
    public abstract T GetBuilding<T>();
}
