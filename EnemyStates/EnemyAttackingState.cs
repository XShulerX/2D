using UnityEngine;


public class EnemyAttackingState : EnemyState
{

    private float _currentTimer;

    public EnemyAttackingState(EnemyController enemyController, EnemyStateMachine stateMachine) : base(enemyController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemyController.EnemyAnim.SetTrigger("isAttack");
        _enemyController.Attack();
        _currentTimer = 0.0f;
    }

    public override void PhysicsUpdate()
    {
        _enemyController.Rigidbody.velocity = new UnityEngine.Vector2(0f, 0f);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (_currentTimer >= _enemyController.AttackDuration)
            _stateMachine.ChangeState(_enemyController.Patrolling);
        _currentTimer += Time.deltaTime;
    }
}
