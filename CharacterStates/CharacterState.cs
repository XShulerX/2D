public abstract class CharacterState
{

    #region Fields

    protected MyCharacterController _characterController;
    protected CharacterStateMachine _stateMachine;

    #endregion


    #region ClassLifeCycles

    protected CharacterState(MyCharacterController characterController, CharacterStateMachine stateMachine)
    {
        this._characterController = characterController;
        this._stateMachine = stateMachine;
    }

    #endregion


    #region Methods

    public virtual void Enter()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {
        if (IsDead())
        {
            _stateMachine.ChangeState(_characterController.Dying);
        }
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }

    private bool IsDead()
    {
        if (_characterController.Health <= 0.0f)
        {
            return true;
        }
        return false;
    }

    #endregion
}
