using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player) : base(player)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Player.rb.velocity = Vector3.zero;
        //Player.rb.isKinematic = true;
    }

    public override void Exit()
    {
        base.Exit();
        //Player.rb.isKinematic = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!Player.grounded)
        {
            Player.ChangeState(Player.AirBorneState);
            return;
        }
        else if (Player.playerInput.movementInput.x != 0)
        {
            Player.ChangeState(Player.MoveState);
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
