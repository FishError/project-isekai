using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityState
{
    protected float startTime;

    public virtual void Enter()
    {
        startTime = Time.time;
    }

    public abstract void Exit();

    public abstract void LogicUpdate();

    public abstract void PhysicsUpdate();
}
