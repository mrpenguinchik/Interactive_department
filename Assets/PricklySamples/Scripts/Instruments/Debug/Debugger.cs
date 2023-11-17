using UnityEngine;
using NaughtyAttributes;
using Prickly.Core;

namespace Prickly
{
    namespace Debug
    {
        [ExecuteInEditMode, RequireComponent(typeof(FPS))]
        public class Debugger : InGameObject, IInitializable<GameConfig>
        {
            [Header("Main")]
            [SerializeField] private bool _updateInEditor;

            [Header("Preferences")]
            [SerializeField] private FPS _fpsDebug;
            [SerializeField] private Animation _animationDebug;

            private bool _canShowAnimationButton => _animationDebug != null;

            private void OnEnable()
            {
                if (Application.isPlaying == true)
                {
                    _updateInEditor = false;
                }
            }

            public void Init(GameConfig gameConfig)
            {
                _fpsDebug.Init(gameConfig.FrameRate);
                _animationDebug?.Init();
                //add other debug preferences   
            }

            private void Update()
            {
                if (_updateInEditor == false)
                    return;

                _fpsDebug.Log();
            }

            [ShowIf("_canShowAnimationButton"), Button]
            private void DebugAnimation()
            {
                _animationDebug.Log();
            }
        }
    }
}
