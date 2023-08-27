using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirBorneState : PlayerState
{
    public PlayerAirBorneState(Player player) : base(player)
    {

    }

    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {
        if (Player.grounded)
        {
            if (Player.playerInput.movementInput.x == 0)
            {
                Player.ChangeState(Player.IdleState);
                return;
            }
            else
            {
                Player.ChangeState(Player.MoveState);
                return;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        Player.rb.velocity = new Vector2(Player.playerInput.movementInput.x * 5, Player.rb.velocity.y);
    }

    public override void OnMove(Vector2 moveInput)
    {
        Player.rb.velocity = new Vector2(moveInput.x * 5, Player.rb.velocity.y);
    }

    public override void OnJump()
    {
        
    }
}
