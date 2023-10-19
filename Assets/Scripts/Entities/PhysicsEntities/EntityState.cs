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

    public virtual void OnCollisionEnter(Collision2D collision)
    {

    }

    public virtual void OnCollisionStay(Collision2D collision)
    {

    }

    public virtual void OnCollisionExit(Collision2D collision)
    {

    }

    public virtual void OnTriggerEnter(Collider2D collision)
    {

    }

    public virtual void OnTriggerStay(Collider2D collision)
    {

    }

    public virtual void OnTriggerExit(Collider2D collision)
    {

    }
}
