using UnityEngine;


public class Coin : MonoBehaviour
{
    #region Fields

    [SerializeField] private int _scorePoints = 10;
    private AudioSource _audio;
    private SpriteRenderer _sprite;
    private BoxCollider2D _collider;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MyCharacterController>().CoinPickUp(_scorePoints);
            _audio.Play();
            GetComponent<Animator>().SetBool("pickUp", true);
            Destroy(gameObject, 1.5f);
        }
    }

    #endregion
}
