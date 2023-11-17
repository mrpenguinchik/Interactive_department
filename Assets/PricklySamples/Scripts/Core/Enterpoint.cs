using NaughtyAttributes;
using Prickly.Debug;
using UnityEngine;

namespace Prickly
{
    namespace Core
    {
        public sealed class Enterpoint : InGameObject
        {
            [HorizontalLine, Header("Core")]
            [SerializeField] private GameConfig _gameConfig;
            [SerializeField] private NewPlayGameState _playGameState;

            [HorizontalLine, Header("Debug")]
            [SerializeField] private Debugger _debugger;

            private void Awake()
            {
               
                _playGameState.Init(_gameConfig);
            }
        }
    }
}
