using System;
using UnityEngine;

public abstract class Interactable<T> : InGameObject
{
    [SerializeField] private Overlap _overlap;
    protected virtual bool CanInteract { get => true; }
    public Action OnStartInteract;
    public Action OnEndInteract;

    [NaughtyAttributes.ShowNonSerializedField] private bool _isInteract;
    internal bool IsInteract
    {
        get
        {
            return _isInteract;
        }
        set
        {
            if (value == _isInteract)
            {
                return;
            }

            if (value == true)
                OnStartInteract?.Invoke();
            else
                OnEndInteract?.Invoke();

            _isInteract = value;
        }
    }

    protected abstract void OnInteract(T obj);

    private void Update()
    {
        if (CanInteract == false)
            return;

        T obj = _overlap.GetTarget<T>();
        if (obj == null)
        {
            IsInteract = false;
            return;
        }

        IsInteract = true;
        OnInteract(obj);
    }
}