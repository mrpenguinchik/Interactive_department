using UnityEngine;
using Prickly.Core;

namespace Prickly
{
    namespace UI
    {
        namespace Windows
        {
            [RequireComponent(typeof(UIController))]
            public abstract class Window : InGameObject, IInitializable
            {
                [SerializeField] private UIController _uIController;

                public abstract void Init();

                public void Show(bool isSmooth = false)
                {
                    if (isSmooth == true)
                    {
                        _uIController.ShowSmoothly();
                        return;
                    }

                    _uIController.Show(true);
                }

                public void Hide(bool isSmooth = false)
                {
                    if (isSmooth == true)
                    {
                        _uIController.HideSmoothly();
                        return;
                    }

                    _uIController.Hide(true);
                }
            }
        }
    }
}
