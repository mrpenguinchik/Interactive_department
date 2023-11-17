using UnityEngine;

[RequireComponent(typeof(VehicleMovement))]
public class VehicleMovement : Movement
{
    [SerializeField] private Wheels _wheels;

    [SerializeField] private float _maxSteerAngle;
    [SerializeField] private Transform _leftRotation;
    [SerializeField] private Transform _rightRotation;

    protected override void OnUpdate()
    {
        _wheels.Spin(Velocity);
        Rotate(Direction);
    }

    private void Rotate(Vector3 direction)
    {
        float angle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);

        float value = angle / Mathf.Abs(angle);
        angle = Mathf.Abs(angle) > _maxSteerAngle ? _maxSteerAngle * value : angle;

        _leftRotation.localRotation = Quaternion.Euler(_leftRotation.localRotation.eulerAngles.x, angle, _leftRotation.localRotation.eulerAngles.z);
        _rightRotation.localRotation = Quaternion.Euler(_rightRotation.localRotation.eulerAngles.x, angle, _rightRotation.localRotation.eulerAngles.z);
    }

    [System.Serializable]
    private class Wheels
    {
        [SerializeField] private float _maxRotationSpeed;

        [SerializeField] private Wheel[] _wheels;

        [System.Serializable]
        private struct Wheel
        {
            [SerializeField] private Transform _wheel;
            [SerializeField] private Vector3 _wheelAxis;

            public void Spin(float angle)
            {
                _wheel.Rotate(_wheelAxis * angle, Space.Self);
            }
        }

        public void Spin(float velocity)
        {
            float angle = velocity * _maxRotationSpeed * Time.deltaTime;

            foreach (Wheel wheel in _wheels)
            {
                wheel.Spin(angle);
            }
        }
    }
}
