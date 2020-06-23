public class EnemyStateMachine
{
    #region Fields

    public EnemyState CurrentState { get; private set; }

    #endregion

    #region Methods

    public void Initialize(EnemyState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(EnemyState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
    #endregion
}
