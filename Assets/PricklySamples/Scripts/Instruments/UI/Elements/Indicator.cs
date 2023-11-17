using UnityEngine.UI;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] private Image _indicator;

    public bool SetFill(float value)
    {
        gameObject.SetActive(value > 0);

        _indicator.fillAmount = value;

        return _indicator.fillAmount == 1;
    }
}
