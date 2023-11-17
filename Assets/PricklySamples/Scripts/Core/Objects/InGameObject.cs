using UnityEngine;

public abstract class InGameObject : MonoBehaviour
{
    protected bool Initialized;

    public void ActiveSelf(bool active)
    {
        gameObject.SetActive(active);
    }
}
