using UnityEngine;


public class EnemyController : MonoBehaviour
{
    #region Fields

    [SerializeField] private LayerMask _maskPlatform;
    [SerializeField] private LayerMask _maskPlayer;
    [SerializeField] private int _health = 2;
    [SerializeField] private int _damage = 15;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _minimalDistanceToDeadLock = 1.15f;
    [SerializeField] private float _minimalDistanceToAttack = 1.65f;
    [SerializeField] private float _distanceToDetectePlayer = 7.0f;
    [SerializeField] private float _attackDuration = 5.0f;
    [SerializeField] private float _timeToDestroy = 5.0f;

    public EnemyPatrollingState Patrolling;
    public EnemyWalkingState Walking;
    public EnemyAttackingState Attacking;
    public EnemyDyingState Dying;

    private EnemyStateMachine _movementStateMachine;
    private Transform _enemyTransform;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _sprite;
    private MyAnimator _enemyAnim;

    private Vector3 _offset;
    private float _reloadTimer = 0.0f;
    private float _direction = 1.0f;

    #endregion


    #region Properties

    public MyAnimator EnemyAnim
    {
        get => _enemyAnim;
        set => _enemyAnim = value;
    }

    public Transform EnemyTransform
    {
        get => _enemyTransform;
        set => _enemyTransform = value;
    }

    public SpriteRenderer Sprite
    {
        get => _sprite;
    }

    public Rigidbody2D Rigidbody
    {
        get => _rigidbody;
        set => _rigidbody = value;
    }

    public LayerMask MaskPlatform
    {
        get => _maskPlatform;
     }

    public LayerMask MaskPlayer
    {
        get => _maskPlayer;
    }

    public Vector3 Offset
    {
        get => _offset;
    }

    public int Health
    {
        get => _health;
    }

    public float MinimalDistanceToDeadLock
    {
        get => _minimalDistanceToDeadLock;
    }

    public float MinimalDistanceToAttack
    {
        get => _minimalDistanceToAttack;
    }

    public float Direction
    {
        get => _direction;
        set => _direction = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public float AttackDuration
    {
        get => _attackDuration;
        set => _attackDuration = value;
    }

    public float DistanceToDetectePlayer
    {
        get => _distanceToDetectePlayer;
        set => _distanceToDetectePlayer = value;
    }

    #endregion


    #region UnityMethods

    private void Start()
    {
        _offset = new Vector3(0, 0.2f);
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyAnim = GetComponent<MyAnimator>();
        _enemyTransform = transform;

        _movementStateMachine = new EnemyStateMachine();
        Patrolling = new EnemyPatrollingState(this, _movementStateMachine);
        Attacking = new EnemyAttackingState(this, _movementStateMachine);
        Dying = new EnemyDyingState(this, _movementStateMachine);

        _movementStateMachine.Initialize(Patrolling);
    }

    private void FixedUpdate()
    {
        _movementStateMachine.CurrentState.PhysicsUpdate();
    }

    private void Update()
    {
        _movementStateMachine.CurrentState.LogicUpdate();
    }


    #endregion


    #region Methods

    public void Attack()
    {
        var direction = new Vector2(_direction, 0);
        var playerMask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(transform.position + _offset, direction, _minimalDistanceToAttack, playerMask);

        if (hit)
        {
            hit.collider.gameObject.GetComponent<MyCharacterController>().Hurt(_damage);
            //_reloadTimer = 0;
        }
    }

    public void Move()
    {
        _enemyAnim.SetFloat("Speed", 1.0f);
        _rigidbody.velocity = new Vector2(_direction * _speed, _rigidbody.velocity.y);
    }

    public void Hurt(int damage)
    {
        _health -= damage;
    }

    public void Die()
    {
        EnemyAnim.SetTrigger("isDead");
        Destroy(gameObject, _timeToDestroy);
    }

    #endregion
}
