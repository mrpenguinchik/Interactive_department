using Prickly.Core;
using Prickly.Gameplay;
using UnityEngine;

[RequireComponent(typeof(VehicleMovement))]
public class Vehicle : Player
{
    [SerializeField] private VehicleMovement _vehicleMovement;

    public override void Init(IController controller, PlayerStat stat)
    {
        _vehicleMovement.Init(controller, stat.MovementStat);
    }

    protected override void OnUpdate()
    {
        
    }
}
