using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public override void OnMove(InputAction.CallbackContext value)
    {
        base.OnMove(value);
        Player.rb.velocity = new Vector2(Player.playerInput.movementInput.x * Player.RelativeSpd, Player.rb.velocity.y);
    }

    public override void OnJump()
    {
        base.OnJump();
        Player.velocities.Add(new Vector2(0, 7));
        Player.playerInput.isJumping = true;
    }

    public override void OnLeftClick(Vector2 mousePos)
    {
        base.OnLeftClick(mousePos);
        Player.ChangeState(Player.BasicAttackState);
    }
}
