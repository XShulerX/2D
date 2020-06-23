public class DyingState : CharacterState
{
    #region ClassLifeCycles

    public DyingState(MyCharacterController characterController, CharacterStateMachine stateMachine) : base(characterController, stateMachine)
    {
    }

    #endregion


    #region Methods

    public override void Enter()
    {
        base.Enter();
        Die();
    }

    public override void LogicUpdate()
    {

    }

    private void Die()
    {
        _characterController.MyAnim.SetTrigger("isDead");
    }
    #endregion;
}
