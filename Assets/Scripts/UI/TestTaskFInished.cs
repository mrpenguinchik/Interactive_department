
using System;
using UnityEngine;

[Serializable]
public class TestTaskFInished
{
    [SerializeField] private Sprite _image;
    [SerializeField] private string _text;
    [SerializeField] private Color _colorOfText;
    public Sprite Image => _image;
    public string Text => _text;
    public Color Color => _colorOfText;
}
