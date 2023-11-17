using UnityEngine;
using NaughtyAttributes;
using System;
using Prickly.Core;

namespace Prickly
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "Core/GameConfig", order = 51)]
    public class GameConfig : ScriptableObject
    {
        private const int DEFAULT_FRAME_RATE = 30;

        [Header("Core")]
        [SerializeField] private int _frameRate = 60;
        [SerializeField] private Controller _controller;

        public int FrameRate => _frameRate < DEFAULT_FRAME_RATE ? DEFAULT_FRAME_RATE : _frameRate;
        public Controller Controller => _controller;

        [HorizontalLine, Header("Stats")]
        [SerializeField] PlayerStat _playerStat;

        public PlayerStat PlayerStat => _playerStat;
    }

    namespace Core
    {
        [Serializable]
        public struct PlayerStat
        {
            public MovementStat MovementStat;
        }

        [Serializable]
        public struct MovementStat
        {
            public float MaxSpeed;
            public float MaxRotationSpeed;
        }
    }
}
