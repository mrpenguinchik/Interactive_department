using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestZone : Interactable<IPlayer>
{
    [SerializeField] private Transform _point;
    public Transform Point => _point;

    protected override void OnInteract(IPlayer player)
    {
    }
}