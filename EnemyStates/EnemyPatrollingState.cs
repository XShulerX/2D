using UnityEngine;


public class EnemyPatrollingState : EnemyWalkingState
{

    #region ClassLifeCycles

    public EnemyPatrollingState(EnemyController enemyController, EnemyStateMachine stateMachine) : base(enemyController, stateMachine)
    {
    }

    #endregion


    #region Methods

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Patrolling();
    }
    
    private void Patrolling()
    {
        var enemyPosition = _enemyController.EnemyTransform.position;
        var direction = new Vector2(_enemyController.Direction, 0);
        RaycastHit2D hitPlayer = Physics2D.Raycast(enemyPosition, direction, _enemyController.MinimalDistanceToAttack, _enemyController.MaskPlayer);
        if (hitPlayer)
        {
            _stateMachine.ChangeState(_enemyController.Attacking);
        }
    }

    public override void Exit()
    {
        base.Exit();
        _enemyController.EnemyAnim.SetFloat("Speed", 0.0f);
    }

    #endregion
}
