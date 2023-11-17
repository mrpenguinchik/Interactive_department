using UnityEngine;
using NaughtyAttributes;

namespace Prickly
{
    namespace Debug
    {
        public class FPS : Debug<int>
        {
            [SerializeField] private bool _overrideFrameRate;
            [ShowIf("_overrideFrameRate"), SerializeField] private int _frameRate;
            [ShowIf("_showFPSCounter"), SerializeField, Range(0.01f, 1f)] private float _interval;
            [ShowIf("_showFPSCounter"), SerializeField] private FPSCounter _fpsCounter;

            private bool _showFPSCounter;

            public override void Log()
            {
                if (_fpsCounter == null)
                    return;

                _fpsCounter.ActiveSelf(_showFPSCounter);
            }

            public override void Init(int frameRate)
            {
                Application.targetFrameRate = _overrideFrameRate ? _frameRate : frameRate;
                _fpsCounter.Init(_interval);

                Log();
            }

            [Button, HideIf("_showFPSCounter")]
            private void ShowCounter() => _showFPSCounter = true;
            [Button, ShowIf("_showFPSCounter")]
            private void HideCounter() => _showFPSCounter = false;
        }
    }
}
