using Prickly.Core;
using UnityEngine;

namespace Prickly
{
    namespace Gameplay
    {
        [RequireComponent(typeof(HumanoidMovement))]
        public class Humanoid : Player
        {
            [SerializeField] private AnimationController _animationController;
            [SerializeField] private HumanoidMovement _humanoidMovement;

            public override void Init(IController controller, PlayerStat stat)
            {
                _humanoidMovement.Init(controller, stat.MovementStat);
            }

            protected override void OnUpdate()
            {
                _animationController.Set(AnimationController.StateName.Speed, AnimationController.Option.FLOAT, _humanoidMovement.Velocity);
            }
        }
    }
}
