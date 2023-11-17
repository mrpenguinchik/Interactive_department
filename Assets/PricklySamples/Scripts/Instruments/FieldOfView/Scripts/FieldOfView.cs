using UnityEngine;

public class FieldOfView : MonoBehaviour {

    [SerializeField] private float _fov;  
    [SerializeField] private int _rayCount = 5;
    [SerializeField] private bool _isDraw;

    public RaycastHit GetTarget(Vector3 direction, float viewDistance, LayerMask layerMask)
    {
        float angle = GetAngleFromVectorFloat(direction);
        float angleIncrease = _fov / _rayCount;

        for (int i = 0; i <= _rayCount; i++)
        {
            RaycastHit hit;
            Vector3 endDirection = GetVectorFromAngle(angle - (angleIncrease * i) + (_fov * 0.5f));

            Physics.Raycast(transform.position, endDirection, out hit, viewDistance, layerMask);

            if (hit.collider == null)
            {
                DrawRay(endDirection, viewDistance, Color.red);
            }
            else
            {
                DrawRay(endDirection, Vector3.Distance(hit.point, transform.position), Color.green);
                return hit;
            }
        }

        return default;
    }

    private void DrawRay(Vector3 direction, float length, Color color)
    {
        if (_isDraw == false)
            return;

        Debug.DrawRay(transform.position, direction * length, color);
    }

    private Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}
