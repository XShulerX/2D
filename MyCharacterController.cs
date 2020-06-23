using UnityEngine;


public class MyCharacterController : MonoBehaviour
{

    #region Fields

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _startBullet;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private CharacterData _data;
    [SerializeField] private int _score;
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minimalDistanceToGround => _data.MinimalDistanceToGround;
    [SerializeField] private float _minimalDistanceToEnemy => _data.MinimalDistanceToEnemy;
    [SerializeField] private float _jumpForce;

    public StandingState Standing;
    public JumpingState Jumping;
    public AttackingState Attacking;
    public AttackingState AlternativeAttacking;
    public DyingState Dying;

    public CharacterStateMachine _movementStateMachine;
    private MyAnimator _myAnim;
    private AudioController _audioController;
    private Transform _transform;
    private IInteractable _interactable;
    private float _horizontalDirection;

    #endregion


    #region Properties

    public Rigidbody2D Rigidbody
    {
        get;
        private set;
    }

    public Transform CharacterTransform
    {
        get => _transform;
        private set => _transform = value;
    }

    public Transform StartBullet
    {
        get => _startBullet;
        set => _startBullet = value;
    }

    public MyAnimator MyAnim
    {
        get => _myAnim;
        set => _myAnim = value;
    }

    public float MaxHealth
    {
        get
        {
            return _data.MaxHealth;
        }
    }

    public float Health
    {
        get => _data.Health;
        private set {
            _data.Health = value;
            _data.NotifyObservers();
        }
    }

    public float Speed => _data.Speed;

    public float JumpForce => _data.JumpForce;

    public int Score
    {
        get => _data.Score;
        private set
        {
            _data.Score = value;
            _data.NotifyObservers();
        }
    }

    public AudioController AudioController
    {
        get => _audioController;
        private set => _audioController = value;
    }

    #endregion


    #region UnityMethods

    private void Start()
    {
        MyAnim = GetComponent<MyAnimator>();
        AudioController = GetComponent<AudioController>();
        Rigidbody = GetComponent<Rigidbody2D>();
        CharacterTransform = transform;
        _movementStateMachine = new CharacterStateMachine();

        Standing = new StandingState(this, _movementStateMachine);
        Jumping = new JumpingState(this, _movementStateMachine);
        Attacking = new AttackingState(this, _movementStateMachine, 0);
        AlternativeAttacking = new AttackingState(this, _movementStateMachine, 1);
        Dying = new DyingState(this, _movementStateMachine);

        _movementStateMachine.Initialize(Standing);
    }

    private void Update()
    {
        _movementStateMachine.CurrentState.HandleInput();
        _movementStateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _movementStateMachine.CurrentState.PhysicsUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            _interactable = collision.gameObject.GetComponent(typeof(IInteractable)) as IInteractable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            _interactable = null;
        }
    }

    #endregion


    #region Methods

    public void Fire()
    {
        RaycastHit2D hit = Physics2D.Raycast(CharacterTransform.position, transform.right, _minimalDistanceToEnemy, _enemyMask);
        if (hit)
        {
            var enemy = hit.collider.gameObject.GetComponent<EnemyController>();
            enemy.Hurt(10);
        }
    }

    public void AlternativeFire()
    {
        Instantiate(_bullet, StartBullet.position, StartBullet.rotation);
    }

    public void Act()
    {
        if(_interactable != null)
        {
            _interactable.Interact();
        }
    }

    public void Move(float speed, float direction)
    {
        Rigidbody.velocity = new Vector2(direction * speed, Rigidbody.velocity.y);
    }

    public void Hurt(int damage)
    {
        Health -= damage;
    }

    public void Heal(int points)
    {
        Health += points;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void CoinPickUp(int scorePoints)
    {
        Score += scorePoints;
    }

    public bool IsGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(CharacterTransform.position, Vector2.down, _minimalDistanceToGround, _groundMask);
        if (hit)
        {
            return true;
        }
        return false;
    }

    #endregion

}
