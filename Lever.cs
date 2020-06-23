using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private FixedJoint2D _cage;
    private Animator _myAnimator;
    private AudioSource _myAudio;
    private bool _active = false;

    private void Start()
    {
        _myAudio = GetComponent<AudioSource>();
        _myAnimator = GetComponent<Animator>();
    }

    public void Interact()
    {
        _active = !_active;
        _myAnimator.SetBool("isActive", _active);
        _myAudio.Play();
        if(_cage != null)
        {
            Destroy(_cage);
        }
    }
}
