using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAirBorneState : SlimeState
{
    public SlimeAirBorneState(Slime slime) : base(slime)
    {
    }

    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {
        if (Slime.grounded && Slime.rb.velocity.y <= 0)
        {
            Slime.ChangeState(Slime.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
