using UnityEngine;

namespace Prickly
{
    namespace UI
    {
        namespace Windows
        {
            [AddComponentMenu("Prickly Games/UI/Windows/Upgrade", 51)]
            public class Upgrade : Window
            {
                [SerializeField] private ButtonBehavior _closeButton;

                public override void Init()
                {
                    _closeButton.Init(() => gameObject.SetActive(false));
                }
            }
        }
    }
}
