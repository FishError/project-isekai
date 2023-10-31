using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBasicAttackAirState : PlayerAirBorneState
{
    public PlayerBasicAttackAirState(Player player) : base(player)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Player.StmRegenerationSetActive(false);
        Player.ModifyStm(-1);
        Player.spriteRenderer.enabled = false;
        Player.weapon.SetAnimatorBoolToFalse("Exit");
        Player.weapon.SetAnimatorBoolToTrue("AirAttack");
        Player.FlipLocalScaleX(Mathf.Sign(Player.playerInput.RelativeLeftClickPos.x));
        if (Mathf.Abs(Player.playerInput.RelativeLeftClickPos.y) > Mathf.Abs(Player.playerInput.RelativeLeftClickPos.x))
        {
            Player.weapon.animator.SetFloat("xMouse", 0);
            if (Player.playerInput.RelativeLeftClickPos.y > 0)
            {
                Player.weapon.animator.SetFloat("yMouse", 1);
            }
            else
            {
                Player.weapon.animator.SetFloat("yMouse", -1);
            }
        }
        else
        {
            Player.weapon.animator.SetFloat("xMouse", 1);
            Player.weapon.animator.SetFloat("yMouse", 0);
        }
    }

    public override void Exit() 
    {
        base.Exit(); 
        Player.StmRegenerationSetActive(true);
        Player.weapon.animator.Play("Idle");
        Player.weapon.animator.SetBool("Exit", true);
        Player.spriteRenderer.enabled = true;
    }

    public void OnAnimationEnd()
    {
        if (!Player.grounded)
        {
            Player.ChangeState(Player.AirBorneState);
            return;
        }
    }

    public override void OnMove(InputAction.CallbackContext value)
    {
        Player.rb.velocity = new Vector2(Player.playerInput.MovementInput.x * Player.RelativeSpd, Player.rb.velocity.y);
    }

    public override void OnLeftClick(Vector2 mousePos, Vector2 relativeMousePos)
    {
        
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        base.OnTriggerEnter(collision);
        Player.weapon.OnTriggerEnter2D(collision);
    }
}
