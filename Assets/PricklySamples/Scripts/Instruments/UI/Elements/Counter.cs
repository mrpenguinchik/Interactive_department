using UnityEngine;
using Prickly.Core;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Prickly
{
    namespace UI
    {
        [System.Serializable]
        public class Counter : InGameObject, IInitializable<Sprite>
        {
            [SerializeField] private Image _icon;
            [SerializeField] private TMP_Text _text;
            private DOTweenAnimation _tween;

            public void Init(Sprite sprite)
            {
                _icon.sprite = sprite;
            }

            public void SetText(string text)
            {
                _text.text = text;

                _tween?.DORestart();
            }
        }
    }
}
