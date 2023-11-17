using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Prickly.Core;

[RequireComponent(typeof(Button))]
public class ButtonBehavior : InGameObject, IInitializable<Action>
{
    private Button _button;
    private UnityAction OnPressed;

    public void Init(Action action)
    {
        UnityAction unityAction = new UnityAction(action);
        OnPressed = unityAction;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnPressed);
    }

    public void SetInteractive(bool enable)
    {
        _button.interactable = enable;
    }
}
