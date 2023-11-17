using System;
using UnityEngine;
using Prickly.Utils;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public enum StateName
    {
        Speed = 0,
        IsMove,
        IsPickUp
    }

    public enum Option
    {
        BOOL,
        TRIGGER,
        FLOAT,
        INT
    }

    public void Set<T>(StateName stateName, Option option, T value) => Set<T>(stateName.ToString(), option, value);

    protected internal void Set<T>(string stateName, Option option, object value = null)
    {
        Action result = option switch
        {
            Option.BOOL => () => { Bool(stateName, Utils.Unboxing<T, bool>(value)); },
            Option.TRIGGER => () => { Trigger(stateName); },
            Option.INT => () => { Int(stateName, Utils.Unboxing<T, int>(value)); },
            Option.FLOAT => () => { Float(stateName, Utils.Unboxing<T, float>(value)); },
            _ => throw new NotImplementedException()
        };

        result?.Invoke();
    }

    private void Bool(string stateName, bool value)
    {
        _animator.SetBool(stateName, value);
    }

    private void Trigger(string stateName)
    {
        _animator.SetTrigger(stateName);
    }

    private void Int(string stateName, int value)
    {
        _animator.SetInteger(stateName, value);
    }

    private void Float(string stateName, float value)
    {
        _animator.SetFloat(stateName, value);
    }
}
