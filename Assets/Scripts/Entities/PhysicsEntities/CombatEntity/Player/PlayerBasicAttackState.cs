using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBasicAttackState : PlayerState
{
    private bool continueCombo;

    public PlayerBasicAttackState(Player player) : base(player)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Player.rb.velocity = Vector2.zero;
        Player.FlipLocalScaleX(Mathf.Sign(Player.playerInput.leftClickPos.x - Player.transform.position.x));
        Vector2 mousePos = Player.playerInput.leftClickPos - (Vector2)Player.transform.position;
        Player.animator.SetBool("BasicAttack", true);
        if (mousePos.y > Mathf.Abs(mousePos.x))
            Player.animator.SetBool("BasicAttackUp", true);
    }

    public override void Exit()
    {
        Player.animator.SetBool("BasicAttackUp", false);
        Player.animator.SetBool("BasicAttack", false);
        continueCombo = false;
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
        Player.velocities.Add(new Vector2(0, 7));
        Player.playerInput.isJumping = true;
    }

    public override void OnLeftClick(Vector2 mousePos)
    {
        base.OnLeftClick(mousePos);
        continueCombo = true;
    }

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

    public override void OnTriggerEnter(Collider2D collision)
    {
        base.OnTriggerEnter(collision);
        CombatEntity entity = collision.attachedRigidbody.GetComponent<CombatEntity>(); 
        if (entity != null)
        {
            entity.ApplyPhysicalDmg(Player.CurrentStr);
        }
    }
}
