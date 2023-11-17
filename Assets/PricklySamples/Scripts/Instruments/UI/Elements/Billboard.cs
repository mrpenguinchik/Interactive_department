using Prickly.Gameplay;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private MainCamera targetCamera;
    [SerializeField] private bool _ignoreY;
    [SerializeField] private bool _revertForward;

    private void Start()
    {
        targetCamera = FindObjectOfType<MainCamera>();
    }

    private void LateUpdate()
    {
        Vector3 targetDirection = targetCamera.transform.position - transform.position;
        if (_ignoreY)
            targetDirection.y = 0;
        if (_revertForward)
            targetDirection = -targetDirection;
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = lookRotation;
    }
}