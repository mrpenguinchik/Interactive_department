using Prickly.Core;
using Prickly.UI;
using UnityEngine;

public class FPSCounter : InGameObject, IInitializable<float>
{
    [SerializeField] private Text _text;

    private float _interval;
    private float _t;
    private int _frames;
    private float _accum;

    public void Init(float interval)
    {
        _interval = interval;
    }

    private void Update()
    {
        if (_text == null || Initialized == false)
            return;

        _t -= Time.deltaTime;
        _accum += Time.timeScale / Time.deltaTime;
        _frames++;

        if (_t <= 0)
        {
            var fps = Mathf.RoundToInt(_accum / _frames);

            if (fps >= 59) _text.color = Color.green;
            else _text.color = Color.yellow;
            _text.text = fps.ToString();
            _t = _interval;
            _accum = 0;
            _frames = 0;
        }
    }
}
