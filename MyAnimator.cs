using UnityEngine;


public class MyAnimator : MonoBehaviour
{

    #region Fields

    private Animator _animator;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    #endregion


    #region Methods

    public void SetBool(string name, bool value)
    {
        _animator.SetBool(name, value);
    }

    public void SetTrigger(string name)
    {
        _animator.SetTrigger(name);
    }

    public void SetFloat(string name, float value)
    {
        _animator.SetFloat(name, value);
    }

    #endregion
}
