public class EnemyDyingState : EnemyState
{

    #region ClassLifeCycles

    public EnemyDyingState(EnemyController enemyController, EnemyStateMachine stateMachine) : base(enemyController, stateMachine)
    {
    }

    #endregion


    #region Methods

    public override void Enter()
    {
        base.Enter();
        _enemyController.Die();
    }

    public override void LogicUpdate()
    {

    }

    public override void PhysicsUpdate()
    {
        _enemyController.Rigidbody.velocity = new UnityEngine.Vector2(0f, 0f);
    }

    #endregion;
}
