using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMoveState : BasicEnemyGroundedState
{
    public BasicEnemyMoveState(BasicEnemy basicEnemy) : base(basicEnemy)
    {

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (BasicEnemy.target != null)
        {
            BasicEnemy.rb.velocity = new Vector3(BasicEnemy.targetDir.x, 0).normalized * 3 + new Vector3(0, BasicEnemy.rb.velocity.y);
        }
    }
}
