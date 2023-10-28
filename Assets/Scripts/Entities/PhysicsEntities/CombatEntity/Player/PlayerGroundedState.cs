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
        Player.rb.velocity = new Vector2(Player.playerInput.MovementInput.x * Player.RelativeSpd, Player.rb.velocity.y);
    }

    public override void OnJump()
    {
        base.OnJump();
        Player.Jump();
    }

    public override void OnLeftClick(Vector2 mousePos, Vector2 relativeMousePos)
    {
        base.OnLeftClick(mousePos, relativeMousePos);
        Player.ChangeState(Player.BasicAttackState);
    }
}
