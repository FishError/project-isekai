using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    public BasicEnemyIdleState IdleState { get; private set; }
    public BasicEnemyMoveState MoveState { get; private set; }

    public override void SetBaseStats(CombatEntityData data)
    {
        
    }

    protected override void SetupStateMachine()
    {
        IdleState = new BasicEnemyIdleState(this);
        MoveState = new BasicEnemyMoveState(this);
        CurrentState = IdleState;
    }
}
