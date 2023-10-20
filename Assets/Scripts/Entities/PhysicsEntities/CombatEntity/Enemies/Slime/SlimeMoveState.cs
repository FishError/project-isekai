using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoveState : SlimeGroundedState
{
    private Vector2 moveDir;

    public SlimeMoveState(Slime slime) : base(slime)
    {

    }

    public override void Enter()
    {
        base.Enter();
        if (Slime.target == null)
        {
            moveDir = new Vector2((Random.value < 0.5f) ? -1 : 1, 0);
            Slime.ChangeState(Slime.IdleState, Random.Range(1f, 3f));
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!Slime.grounded)
        {
            Slime.ChangeState(Slime.AirBorneState);
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (Slime.target != null)
        {
            if (Vector2.Distance(Slime.targetPos, Slime.transform.position) < 5)
            {
                Slime.rb.velocity = Vector2.zero;
                Slime.velocities.Add(CalculateLeapVelocity());
                Slime.ChangeState(Slime.LeapState);
                return;
            }
            Slime.rb.velocity = new Vector3(Slime.targetDir.x, 0).normalized * Slime.RelativeSpd + new Vector3(0, Slime.rb.velocity.y);
        }
        else
        {
            Slime.rb.velocity = moveDir * Slime.RelativeSpd;
            Slime.transform.right = new Vector2(Mathf.Sign(Slime.rb.velocity.x), 0);
        }
    }

    private Vector2 CalculateLeapVelocity()
    {
        float xVelocity = Slime.RelativeSpd + 2;
        float t = Mathf.Abs(Slime.targetPos.x - Slime.transform.position.x) / xVelocity;
        float yVelocity = ((Slime.targetPos.y - Slime.transform.position.y) - (-Slime.gravity * Mathf.Pow(t, 2)) / 2) / t;
        return new Vector2(Mathf.Sign(Slime.targetDir.x) * xVelocity, (yVelocity > 6) ? 6 : yVelocity );
    }
}
