using System.Collections;
using UnityEngine;

namespace Prickly
{
    namespace UI
    {
        [RequireComponent(typeof(CanvasGroup))]
        public class UIController : MonoBehaviour
        {
            private CanvasGroup _canvasGroup;

            internal void Show(bool changeActive)
            {
                if (changeActive == true)
                {
                    gameObject.SetActive(true);
                }

                if (_canvasGroup == null)
                {
                    _canvasGroup = GetComponent<CanvasGroup>();
                }

                _canvasGroup.alpha = 1;
                _canvasGroup.interactable = true;
                _canvasGroup.blocksRaycasts = true;
            }

            public void Hide(bool changeActive)
            {
                if (_canvasGroup == null)
                {
                    _canvasGroup = GetComponent<CanvasGroup>();
                }

                _canvasGroup.alpha = 0;
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;

                if (changeActive == false)
                    return;

                gameObject.SetActive(false);
            }

            public void ShowSmoothly()
            {
                gameObject.SetActive(true);
                StartCoroutine(VisibleChanger(false));
            }

            public void HideSmoothly()
            {
                gameObject.SetActive(true);
                StartCoroutine(VisibleChanger(true));
            }

            private IEnumerator VisibleChanger(bool isHide)
            {
                if (_canvasGroup == null)
                {
                    _canvasGroup = GetComponent<CanvasGroup>();
                }

                float startValue = isHide == true ? 1 : 0;
                float endValue = isHide == true ? 0 : 1;

                for (float i = startValue; i <= endValue; i += 0.05f)
                {
                    _canvasGroup.alpha = i;

                    yield return new WaitForSeconds(0.01f);
                }

                if (_canvasGroup.alpha == 0)
                {
                    Hide(false);
                }

                if (_canvasGroup.alpha >= 0.9f)
                {
                    Show(false);
                }
            }
        }
    }
}
