using Prickly.Core;
using Prickly.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : Player
{
    
    [SerializeField] private HumanoidMovement _humanoidMovement;

    public override void Init(IController controller, PlayerStat stat)
    {
        _humanoidMovement.Init(controller, stat.MovementStat);
    }

    protected override void OnUpdate()
    {
    }
}
