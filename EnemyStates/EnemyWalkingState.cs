using UnityEngine;


public class EnemyWalkingState : EnemyState
{

    public EnemyWalkingState(EnemyController enemyController, EnemyStateMachine stateMachine) : base(enemyController, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        _enemyController.Move();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        IsDeadLock();
    }

    protected void IsDeadLock()
    {
        var position = _enemyController.EnemyTransform.position + _enemyController.Offset;
        var direction = new Vector2(_enemyController.Direction, 0);
        RaycastHit2D hitWall = Physics2D.Raycast(position, direction, _enemyController.MinimalDistanceToDeadLock, _enemyController.MaskPlatform);
        if (hitWall)
        {
            _enemyController.Direction = -1 * _enemyController.Direction;
            Rotate();
        }
    }

    private void Rotate()
    {
        if (_enemyController.Direction > 0)
        {
            _enemyController.Sprite.flipX = false;
        }
        if (_enemyController.Direction < 0)
        {
            _enemyController.Sprite.flipX = true;
        }
    }

}
