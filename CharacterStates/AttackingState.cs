using UnityEngine;


public class AttackingState : GroundedState
{

    #region Fields

    private int _typeOfAttack;
    private float _currentTimer;
    private float _attackDuration = 0.5f;

    #endregion


    #region ClassLifeCycles

    public AttackingState(MyCharacterController characterController, CharacterStateMachine stateMachine, int typeOfAttack) : base(characterController, stateMachine)
    {
        _typeOfAttack = typeOfAttack;
    }

    #endregion


    #region Methods

    public override void Enter()
    {
        base.Enter();
        _characterController.MyAnim.SetTrigger("isAttack");
        if(_typeOfAttack == 0)
        {
            _characterController.AudioController.SwordAttacking();
            _characterController.Fire();
        }
        else if(_typeOfAttack == 1)
        {
            _characterController.AudioController.FireballAttack();
            _characterController.AlternativeFire();
        }
        _currentTimer = 0.0f;
    }

    public override void LogicUpdate()
    {
        if(_currentTimer >= _attackDuration)
        {
            _stateMachine.ChangeState(_characterController.Standing);
        }
        _currentTimer += Time.deltaTime;
    }

    #endregion
}
