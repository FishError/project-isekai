using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tier
{
    Common,
    Rare,
    Legendary,
    Ultimate
}

public abstract class Skill
{
    public Tier tier;

    public List<Active> Actives { get; protected set; }

    protected CombatEntity entity;

    public Skill(CombatEntity entity)
    {
        Actives = new List<Active>();
        this.entity = entity;
    }

    public abstract void EnablePassive();

    public abstract void DisablePassive();

    public virtual void Effect() { }

    public virtual void OnTakeDamage(float dmg) { }
}
