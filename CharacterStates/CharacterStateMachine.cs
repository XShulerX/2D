public class CharacterStateMachine
{

    #region Fields

    public CharacterState CurrentState { get; private set; }

    #endregion

    #region Methods

    public void Initialize(CharacterState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(CharacterState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
    #endregion
}
