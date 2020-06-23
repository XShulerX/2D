using UnityEngine;


public class Bullet : MonoBehaviour
{

    #region Fields

    [SerializeField] private float _speed = 3;
    [SerializeField] private float _lifeTime = 4;
    [SerializeField] private int _damage = 1;

    private Rigidbody2D _rigidbody;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.Hurt(_damage);
        }

        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
