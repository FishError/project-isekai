using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyIdleState : BasicEnemyGroundedState
{
    public BasicEnemyIdleState(BasicEnemy basicEnemy) : base(basicEnemy)
    {

    }

    public override void Enter()
    {
        base.Enter();
        BasicEnemy.rb.velocity = Vector3.zero;
        BasicEnemy.rb.isKinematic = true;
    }

    public override void Exit()
    {
        base.Exit();
        BasicEnemy.rb.isKinematic = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (BasicEnemy.target != null)
        {
            BasicEnemy.ChangeState(BasicEnemy.MoveState);
            return;
        }
    }
}
