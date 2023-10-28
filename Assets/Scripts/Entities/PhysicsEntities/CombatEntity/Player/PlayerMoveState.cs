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
        Player.rb.velocity = new Vector2(Player.playerInput.MovementInput.x * Player.RelativeSpd, Player.rb.velocity.y);
        Player.animator.SetBool("Running", true);
    }

    public override void Exit()
    {
        base.Exit();
        Player.animator.SetBool("Running", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!Player.grounded)
        {
            Player.ChangeState(Player.AirBorneState);
            return;
        }
        else if (Player.playerInput.MovementInput.x == 0)
        {
            Player.ChangeState(Player.IdleState);
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Player.FlipLocalScaleX(Mathf.Sign(Player.playerInput.MovementInput.x));
        Player.rb.velocity = new Vector2(Player.playerInput.MovementInput.x * Player.RelativeSpd, Player.rb.velocity.y);
    }
}
