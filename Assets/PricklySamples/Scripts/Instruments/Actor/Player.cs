using Prickly.Core;
using UnityEngine;

namespace Prickly
{
    namespace Gameplay
    {
        public abstract class Player : InGameObject, IInitializable<IController, PlayerStat>, IPlayer
        {
            public bool IsAlive => true;
            public Transform Transform => transform;

            public abstract void Init(IController controller, PlayerStat stat);
            protected abstract void OnUpdate();

            private void Update()
            {
                if (IsAlive == false)
                    return;

                OnUpdate();
            }
        }
    }
}
