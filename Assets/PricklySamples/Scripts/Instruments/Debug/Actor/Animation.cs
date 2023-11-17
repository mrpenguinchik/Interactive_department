namespace Prickly
{
    namespace Debug
    {
        using System;
        using NaughtyAttributes;
        using UnityEngine;
        using static AnimationController;

        public class Animation : Debug
        {
            [SerializeField] private AnimationController _animationController;

            [SerializeField] private Option _option;
            [SerializeField] private StateName _stateName;

            [SerializeField] private bool _overrideStateName;
            [ShowIf("_overrideStateName"), SerializeField] private string _name;
            [ShowIf("_option", Option.BOOL)] [SerializeField] private bool _boolean;
            [ShowIf("_option", Option.INT)] [SerializeField] private int _integer;
            [ShowIf("_option", Option.FLOAT)] [SerializeField] private float _floated;

            public override void Init()
            {
                if (_animationController == null)
                    throw new System.NullReferenceException("Setup Debug Module or Remove It");
            }

            public override void Log()
            {
                object obj = _option switch
                {
                    Option.BOOL => _boolean,
                    Option.INT => _integer,
                    Option.FLOAT => _floated,
                    _ => null
                };

                Action action = _option switch
                {
                    Option.BOOL => delegate { _animationController.Set<bool>(_overrideStateName ? _name : _stateName.ToString(), _option, _boolean); },
                    Option.TRIGGER => delegate { _animationController.Set<bool>(_overrideStateName ? _name : _stateName.ToString(), _option); },
                    Option.INT => delegate { _animationController.Set<int>(_overrideStateName ? _name : _stateName.ToString(), _option, _integer); },
                    Option.FLOAT => delegate { _animationController.Set<float>(_overrideStateName ? _name : _stateName.ToString(), _option, _floated); },
                    _ => throw new InvalidOperationException()
                };

                action?.Invoke();
            }
        }
    }
}

