using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestActiveSkill : Skill
{
    public TestActiveSkill(CombatEntity entity) : base(entity)
    {
        Actives.Add(new TestActive());
    }

    public override void EnablePassive()
    {
        throw new System.NotImplementedException();
    }

    public override void DisablePassive()
    {
        throw new System.NotImplementedException();
    }
}
