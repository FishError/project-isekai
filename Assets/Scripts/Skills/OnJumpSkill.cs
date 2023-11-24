using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnJumpSkill : Skill
{
    public OnJumpSkill(CombatEntity entity) : base(entity)
    {

    }

    public override void DisablePassive()
    {
        throw new System.NotImplementedException();
    }

    public override void EnablePassive()
    {
        throw new System.NotImplementedException();
    }

    public abstract void OnJump();
}
