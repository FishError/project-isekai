using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{

    public PlayerGroundedState(Player player) : base(player)
    {

    }

    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {
        
    }

    public override void PhysicsUpdate()
    {
        
    }

    public override void OnMove(Vector2 moveInput)
    {
        Player.rb.velocity = new Vector2(moveInput.x * 5, Player.rb.velocity.y);
    }

    public override void OnJump()
    {
        Player.velocities.Add(new Vector2(0, 7));
        Player.playerInput.isJumping = true;
    }
}
