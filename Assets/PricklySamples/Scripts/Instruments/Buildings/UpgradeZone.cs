using UnityEngine;

public class UpgradeZone : Interactable<IPlayer>
{
    [SerializeField] private Transform _point;
    public Transform Point => _point;

    protected override void OnInteract(IPlayer player)
    {
    }
}
