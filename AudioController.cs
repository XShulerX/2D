using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip _fire;
    [SerializeField] private AudioClip _swordSlash;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SwordAttacking()
    {
        _audioSource.clip = _swordSlash;
    }

    public void FireballAttack()
    {
        _audioSource.clip = _fire;
    }
}
