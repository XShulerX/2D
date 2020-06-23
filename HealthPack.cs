using UnityEngine;

public class HealthPack : MonoBehaviour
{
    #region Fields

    [SerializeField] private int _healthPoints = 20;
    private AudioSource _audio;
    private SpriteRenderer _sprite;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MyCharacterController>().Heal(_healthPoints);
            _audio.Play();
            Destroy(_sprite);
            Destroy(gameObject, 1.0f);
        }
    }

    #endregion
}
