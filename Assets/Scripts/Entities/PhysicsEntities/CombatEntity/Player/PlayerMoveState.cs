using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player) : base(player)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Player.rb.velocity = new Vector3(Player.playerInput.movementInput.x * 5, Player.rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!Player.grounded)
        {
            Player.ChangeState(Player.AirBorneState);
            return;
        }
        else if (Player.playerInput.movementInput.x == 0)
        {
            Player.ChangeState(Player.IdleState);
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (Player.playerInput.movementInput.x != 0)
        {
            Player.rb.velocity = new Vector3(Player.playerInput.movementInput.x * 5, Player.rb.velocity.y);
        }
    }
}
