using UnityEngine;

public interface IPlayer : ICameraTarget
{
    public Transform Transform { get; }
}