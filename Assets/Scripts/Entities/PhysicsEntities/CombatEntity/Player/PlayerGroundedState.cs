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

    public override void OnJump()
    {
        Player.rb.isKinematic = false;
        Player.velocities.Add(new Vector3(0, 5));
    }
}
