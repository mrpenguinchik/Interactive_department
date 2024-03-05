using Prickly.Core;
using NaughtyAttributes;
using UnityEngine;
using System;

public abstract class Movement : InGameObject, IInitializable<IController, MovementStat>, IUpgradable
{
    public bool CanMove => _controller != null && _controller.IsEnabled == true;

    [SerializeField] protected bool _canMove = true;
    [SerializeField] private Rigidbody _rigidbody;
    private IController _controller;

    [Header("Stats")]
    [ShowNonSerializedField] private float _maxSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxRotationSpeed = 10;

    [ShowNonSerializedField] private float _rotationSpeed;
    
    float Rotation=0;
    public float Velocity => Mathf.Max(Mathf.Abs(_controller.Direction.x), Mathf.Abs(_controller.Direction.y));
    public Vector3 Direction => new Vector3(_controller.Direction.x, 0f, _controller.Direction.y);

    public void SetSpeed(float percent)
    {
        _speed = _maxSpeed * percent;
        _rotationSpeed = _maxRotationSpeed * percent;
    }

    protected abstract void OnUpdate();

    public void Init(IController controller, MovementStat stat)
    {
        _controller = controller;
        _controller.IsEnabled = true;

        _maxSpeed = stat.MaxSpeed;
        _maxRotationSpeed = stat.MaxRotationSpeed;

        _speed = _maxSpeed;
        _rotationSpeed = _maxRotationSpeed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        if (CanMove == false)
        {
            _rigidbody.isKinematic = true;
            return;
        }

        Move(Direction);

        OnUpdate();
    }
    private float X, Y, Z,EulerX=0,EulerY=0,speed=100;
    
    private void Move(Vector3 direction)
    {
        /*
            _rigidbody.velocity = _speed * Time.deltaTime * direction;

            if (direction == Vector3.zero)
                return;

            float speed = _rotationSpeed * Velocity;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _controller.Rotate(direction), speed);
   */
        X=Input.GetAxis("Mouse X")*Time.deltaTime*speed;
        Y= -Input.GetAxis("Mouse Y") * Time.deltaTime*speed;
        EulerX = (transform.rotation.eulerAngles.x + Y) % 360;
        EulerY = (transform.rotation.eulerAngles.y + X) % 360;
        transform.rotation = Quaternion.Euler(EulerX, EulerY, 0);
      //  print(transform.rotation.eulerAngles.y);
        _rigidbody.velocity = _speed * Time.deltaTime * direction.z*new Vector3( transform.forward.x,0,transform.forward.z);
        _rigidbody.velocity += _speed * Time.deltaTime * direction.x * new Vector3(transform.right.x, 0, transform.right.z); ;

        //    Rotation += (float)Math.PI * direction.x / (100);
        //    float speed = _rotationSpeed * Velocity;
        //Quaternion rot = _controller.Rotate(new Vector3((float)Math.Sin(Rotation), 0, (float)Math.Cos(Rotation)));
        //rot.x = 0;
        //rot.z = 0;
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation,rot, speed);

    }

    public void StopMove()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    public void OnUpgrade(float value)
    {
        _maxSpeed = value;
    }
}