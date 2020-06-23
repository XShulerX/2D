using UnityEngine;


public class JumpingState : CharacterState
{

    #region Fields

    private bool _grounded;

    #endregion


    #region ClassLifeCycles

    public JumpingState(MyCharacterController characterController, CharacterStateMachine stateMachine) : base(characterController, stateMachine)
    {
    }

    #endregion


    #region Methods

    public override void Enter()
    {
        base.Enter();
        _grounded = false;
        Jump();
    }

    public override void Exit()
    {
        base.Exit();
        _characterController.MyAnim.SetBool("isLanding", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _grounded = _characterController.IsGround();
        if (_grounded)
        {
            _stateMachine.ChangeState(_characterController.Standing);
        }
        else
        {
            if(_characterController.Rigidbody.velocity.y <= 0)
            {
                _characterController.MyAnim.SetBool("isJump", false);
                _characterController.MyAnim.SetBool("isLanding", true);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void Jump()
    {
        _characterController.MyAnim.SetBool("isJump", true);
        _characterController.Rigidbody.AddForce(Vector2.up * _characterController.JumpForce, ForceMode2D.Impulse);
    }

    #endregion
}
