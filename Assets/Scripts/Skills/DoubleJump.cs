using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoubleJump : OnJumpSkill
{
    private bool jumped;

    public DoubleJump(CombatEntity entity) : base(entity)
    {

    }

    public override void EnablePassive()
    {
        throw new System.NotImplementedException();
    }

    public override void DisablePassive()
    {
        throw new System.NotImplementedException();
    }

    public override void OnJump()
    {
        if (!entity.grounded && !jumped)
        {
            if (entity.rb.velocity.y < 0)
                entity.rb.velocity = new Vector2(entity.rb.velocity.x, 0);
            
            entity.velocities.Add(new Vector2(0, 5));
            jumped = true;
            entity.StartCoroutine(ResetJumped());
        }
    }

    public IEnumerator ResetJumped()
    {
        yield return new WaitUntil(() => entity.grounded && jumped);
        jumped = false;
    }
}
