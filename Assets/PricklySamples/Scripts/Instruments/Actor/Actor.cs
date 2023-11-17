using Prickly.Core;

public abstract class Actor : IInitializable
{
    public abstract void Init();
    //[SerializeField] protected float _health;
    //protected virtual float MaxHealth { get; }
    //protected virtual float Damage { get; }
    //protected virtual float MaxSpeed { get; }

    //public float GetMaxSpeed() => MaxSpeed;

    /*protected float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;

            if (_health > MaxHealth)
            {
                _health = MaxHealth;
            }

            if (HealthBar != null)
            {
                HealthBar.ChangeSlider(_health);
            }
        }
    }*/

    //[SerializeField] protected float Boost;
    //[SerializeField] protected float ActionDelay;

    //[Header("References")]
    //[SerializeField] protected HealthBar HealthBar;
    //[SerializeField] protected AnimationController AnimationController;
    //[SerializeField] private ParticleSystem _damageFX;
    //[SerializeField] private ParticleSystem _deathFX;
    //[SerializeField] private Feedback _feedback;

    //private Transform _target;

    //[SerializeField] protected FieldOfView AttackView;
    //[SerializeField] protected FieldOfView GroundView;
    //[SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

    /*protected Transform Target
    {
        get
        {
            return _target;
        }
        set
        {
            if (value == null || value != _target)
            {
                StopAllCoroutines();
                AttackRoutine = null;
            }

            _target = value;
        }
    }*/

    //public bool IsAlive => _health > 0;
    //public bool CanMove => _target == null;
    //protected Coroutine AttackRoutine;
    //public UnityAction OnActorDie;

    //    public abstract void Init(PlayerStats stats = default);
    //public abstract void SetController(IController controller);



    //protected abstract void Update();
    /*protected IEnumerator Attack(AnimationController.StateName stateName, UnityAction action)
    {
        yield return new WaitForSeconds(ActionDelay * 0.5f);

  //      AnimationController.PlayAnimationState(stateName);

        yield return new WaitForSeconds(0.2f);

    /*    IDamageable damagable = null;

        Target.TryGetComponent(out damagable);
        if (damagable != null)
        {
            action?.Invoke();
            damagable.OnDamage(Damage);
        }

        yield return new WaitForSeconds(ActionDelay * 0.5f);

        AttackRoutine = null;
    }*/

    /*protected void Attack(Transform target, float damage, int divider)
    {
       /* IDamageable damagable = null;

        target.TryGetComponent(out damagable);
        if (damagable != null)
        {
            damagable.OnDamage(damage / divider);
        }
    }*/
    /* public void OnDamage(float damage)
     {
         if (IsAlive == false)
             return;

         Health -= damage;

         if (_damageFX != null)
         {
             _damageFX.Play();
         }

         _feedback.Play();

         if (Health <= 0)
         {
             AnimationController.PlayAnimationState(AnimationController.StateName.Death);
             OnDie(Die());
             return;
         }
     }

     public void OnDie(IEnumerator routine) => StartCoroutine(routine); 

     protected IEnumerator Die()
     {
         if (HealthBar.CanHide == true)
         {
             HealthBar.gameObject.SetActive(false);
         }

         _skinnedMeshRenderer.enabled = false;
         if (_deathFX != null)
         {
             _deathFX.Play();

             yield return new WaitUntil(() => _deathFX.isPlaying == false);
         }

         OnActorDie?.Invoke();
         _feedback.ScaleToZero();
         gameObject.SetActive(false);
     }

     protected Transform GetTarget(FieldOfView fieldOfView, Vector3 direction, float length, LayerMask layerMask)
     {
         return fieldOfView.GetTarget(direction, length, layerMask);
     }*/
}