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
        Player.animator.SetBool("BasicAttack", true);
    }

    public override void Exit() 
    {
        base.Exit();
        Player.animator.SetBool("BasicAttack", false);
    }

    public void ChangeStateAfterAttack()
    {
        if (!Player.grounded)
        {
            Player.ChangeState(Player.AirBorneState);
        }
    }

    public override void OnMove(InputAction.CallbackContext value)
    {
        Player.rb.velocity = new Vector2(Player.playerInput.movementInput.x * Player.RelativeSpd, Player.rb.velocity.y);
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
