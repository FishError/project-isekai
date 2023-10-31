using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBasicAttackState : PlayerState
{

    public PlayerBasicAttackState(Player player) : base(player)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Player.StmRegenerationSetActive(false);
        Player.rb.velocity = Vector2.zero;
        Player.spriteRenderer.enabled = false;
        Player.weapon.SetAnimatorBoolToFalse("Exit");
        if (Player.playerInput.RelativeLeftClickPos.y > Mathf.Abs(Player.playerInput.RelativeLeftClickPos.x))
        {
            Player.weapon.SetAnimatorBoolToTrue("UpAttack");
        }
        else
        {
            Player.weapon.SetAnimatorBoolToTrue("BasicAttack");
        }
    }

    public override void Exit()
    {
        Player.StmRegenerationSetActive(true);
        Player.weapon.animator.Play("Idle");
        Player.weapon.animator.SetBool("Exit", true);
        Player.spriteRenderer.enabled = true;
    }

    public override void LogicUpdate()
    {
        if (!Player.grounded)
        {
            Player.ChangeState(Player.AirBorneState);
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        
    }

    public override void OnJump()
    {
        base.OnJump();
        Player.Jump();
    }

    public override void OnLeftClick(Vector2 mousePos, Vector2 relativeMousePos)
    {
        base.OnLeftClick(mousePos, relativeMousePos);
        if (Player.CurrentStm >= 1)
        {
            if (relativeMousePos.y > Mathf.Abs(relativeMousePos.x))
            {
                Player.weapon.SetAnimatorBoolToTrue("UpAttack");
            }
            else
            {
                Player.weapon.SetAnimatorBoolToTrue("BasicAttack");
            }
        }
    }

    public void OnAnimationEnter()
    {
        Player.FlipLocalScaleX(Mathf.Sign(Player.playerInput.RelativeLeftClickPos.x));
        Player.ModifyStm(-1);
    }

    public void OnAnimationEnd()
    {
        if (!(Player.weapon.animator.GetBool("BasicAttack") || Player.weapon.animator.GetBool("UpAttack")))
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

    public override void OnTriggerEnter(Collider2D collision)
    {
        base.OnTriggerEnter(collision);
        Player.weapon.OnTriggerEnter2D(collision);
    }
}
