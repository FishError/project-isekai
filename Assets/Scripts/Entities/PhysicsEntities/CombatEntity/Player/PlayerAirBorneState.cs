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
        Player.animator.SetBool("Jumping", true);
    }

    public override void Exit()
    {
        Player.rb.velocity = new Vector2(Player.rb.velocity.x, 0);
        Player.animator.SetBool("Jumping", false);
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
        if (Player.playerInput.movementInput.x != 0)
        {
            Player.transform.localScale = new Vector3(Mathf.Sign(Player.playerInput.movementInput.x) * Mathf.Abs(Player.transform.localScale.x),
                                                    Player.transform.localScale.y,
                                                    Player.transform.localScale.z);
        }
        Player.rb.velocity = new Vector2(Player.playerInput.movementInput.x * Player.RelativeSpd, Player.rb.velocity.y);
    }

    public override void OnMove(InputAction.CallbackContext value)
    {
        base.OnMove(value);
        Player.rb.velocity = new Vector2(value.ReadValue<Vector2>().x * Player.RelativeSpd, Player.rb.velocity.y);
    }
}
