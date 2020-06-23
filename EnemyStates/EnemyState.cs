public abstract class EnemyState
{

    #region Fields

    protected EnemyController _enemyController;
    protected EnemyStateMachine _stateMachine;

    #endregion


    #region ClassLifeCycles

    protected EnemyState(EnemyController enemyController, EnemyStateMachine stateMachine)
    {
        this._enemyController = enemyController;
        this._stateMachine = stateMachine;
    }

    #endregion


    #region Methods

    public virtual void Enter()
    {

    }

    public virtual void LogicUpdate()
    {
        if (IsDead())
        {
            _stateMachine.ChangeState(_enemyController.Dying);
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
        if (_enemyController.Health <= 0.0f)
        {
            return true;
        }
        return false;
    }

    #endregion
}
