using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBasicAttackState : PlayerGroundedState
{
    private bool continueCombo;

    public PlayerBasicAttackState(Player player) : base(player)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Player.rb.velocity = Vector2.zero;
        Player.animator.SetBool("Attacking", true);
    }

    public override void Exit()
    {
        base.Exit();
        Player.animator.SetBool("Attacking", false);
        continueCombo = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void OnLeftClick()
    {
        base.OnLeftClick();
        continueCombo = true;
    }

    public override void OnMove(InputAction.CallbackContext value) { }

    public override void OnJump() { }

    public void ChangeStateAfterAttack()
    {
        if (continueCombo)
        {
            Player.ChangeState(Player.BasicAttackState);
        }
        else
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
}
