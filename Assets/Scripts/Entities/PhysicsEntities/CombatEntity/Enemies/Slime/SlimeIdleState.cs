using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIdleState : SlimeGroundedState
{
    public SlimeIdleState(Slime slime) : base(slime)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Slime.rb.velocity = Vector2.zero;
        Slime.ChangeState(Slime.MoveState, 2);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}
