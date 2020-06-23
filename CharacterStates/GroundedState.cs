using System;
using UnityEngine;


public class GroundedState : CharacterState
{

    #region Fields

    protected float _speed;
    private float _horizontalInput;

    #endregion


    #region ClassLifeCycles

    public GroundedState(MyCharacterController characterController, CharacterStateMachine stateMachine) : base(characterController, stateMachine)
    {
    }

    #endregion


    #region Methods

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0.0f;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        _horizontalInput = Input.GetAxis("Horizontal");
        Rotate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        _characterController.Move(_speed, _horizontalInput);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Math.Abs(_horizontalInput) > 0.0f)
        {
            _characterController.MyAnim.SetFloat("Speed", 1);
        }
        else
        {
            _characterController.MyAnim.SetFloat("Speed", 0);
        }
    }

    private void Rotate()
    {
        if (_horizontalInput > 0.0f)
        {
            _characterController.CharacterTransform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        if (_horizontalInput < 0.0f)
        {
            _characterController.CharacterTransform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
        }
    }

    #endregion
}
