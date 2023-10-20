using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLeapState : SlimeAirBorneState
{
    public SlimeLeapState(Slime slime) : base(slime)
    {
    }

    public override void Exit()
    {
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        
    }

    public override void OnCollisionEnter(Collision2D collision)
    {
        base.OnCollisionEnter(collision);
        CombatEntity entity = collision.rigidbody.gameObject.GetComponent<CombatEntity>();
        if (entity != null)
        {
            entity.ApplyPhysicalDmg(Slime.CurrentStr);
            Slime.velocities.Add(collision.contacts[0].normal * Slime.CurrentSpd * 2);
            Slime.ChangeState(Slime.AirBorneState);
        }
    }
}
