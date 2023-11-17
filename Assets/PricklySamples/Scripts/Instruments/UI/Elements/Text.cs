using UnityEngine;

namespace Prickly
{
    namespace UI
    {
        using TMPro;

        [RequireComponent(typeof(TMP_Text))]
        public class Text : MonoBehaviour
        {
            [SerializeField] private TMP_Text _textView;

            public string text
            {
                get
                {
                    return _text;
                }
                set
                {
                    _text = value;
                    _textView.text = _text;
                }
            }

            public Color color
            {
                get
                {
                    return _color;
                }
                set
                {
                    _textView.color = value;
                }
            }

            private string _text;
            private Color _color;
        }
    }
}

