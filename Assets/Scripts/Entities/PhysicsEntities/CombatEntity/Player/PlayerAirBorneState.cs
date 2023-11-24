using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAirBorneState : PlayerState
{
    public PlayerAirBorneState(Player player) : base(player)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Player.animator.SetBool("Airborne", true);
    }

    public override void Exit()
    {
        if (Player.grounded)
        {
            Player.rb.velocity = new Vector2(Player.rb.velocity.x, 0);
        }
        Player.animator.SetBool("Airborne", false);
    }

    public override void LogicUpdate()
    {
        if (Player.grounded)
        {
            if (Player.playerInput.MovementInput.x == 0)
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
        Player.rb.velocity = new Vector2(Player.playerInput.MovementInput.x * Player.RelativeSpd, Player.rb.velocity.y);
    }

    public override void OnMove(InputAction.CallbackContext value)
    {
        base.OnMove(value);
        if (value.performed)
        {
            Player.FlipLocalScaleX(Mathf.Sign(Player.playerInput.MovementInput.x));
        }
        Player.rb.velocity = new Vector2(Player.playerInput.MovementInput.x * Player.RelativeSpd, Player.rb.velocity.y);
    }

    public override void OnJump()
    {
        base.OnJump();
        Player.OnJumpSkill.OnJump();
    }

    public override void OnLeftClick(Vector2 mousePos, Vector2 relativeMousePos)
    {
        base.OnLeftClick(mousePos, relativeMousePos);
        if (Player.CurrentStm >= 1)
            Player.ChangeState(Player.BasicAttackAirState);
    }
}
