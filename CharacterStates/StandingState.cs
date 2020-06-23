using UnityEngine;


public class StandingState : GroundedState
{

    #region Fields

    private bool _isJump;
    private bool _isAttacking;
    private bool _isAlternativeAttacking;
    private bool _isActing;

    #endregion


    #region ClassLifeCycles

    public StandingState(MyCharacterController characterController, CharacterStateMachine stateMachine) : base(characterController, stateMachine)
    {
    }

    #endregion


    #region Methods

    public override void Enter()
    {
        base.Enter();
        _isJump = false;
        _isAttacking = false;
        _speed = _characterController.Speed;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        _isJump = Input.GetButtonDown("Jump");
        _isAttacking = Input.GetButtonDown("Fire1");
        _isAlternativeAttacking = Input.GetButtonDown("Fire2");
        _isActing = Input.GetButtonDown("Use");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (_isJump)
        {
            _stateMachine.ChangeState(_characterController.Jumping);
        }else if (_isAttacking)
        {
            _stateMachine.ChangeState(_characterController.Attacking);
        }else if (_isAlternativeAttacking)
        {
            _stateMachine.ChangeState(_characterController.AlternativeAttacking);
        }else if (_isActing)
        {
            _characterController.Act();
        }
    }

    #endregion
}
