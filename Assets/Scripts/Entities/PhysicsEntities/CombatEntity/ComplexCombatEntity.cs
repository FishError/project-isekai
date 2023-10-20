using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// uses state machine
public abstract class ComplexCombatEntity : CombatEntity
{
    public EntityState CurrentState { get; protected set; }
    public EntityState PreviousState { get; protected set; }

    private Coroutine changeStateCoroutine;

    protected override void Start()
    {
        base.Start();
        SetupStateMachine();
        CurrentState.Enter();
    }

    protected override void Update()
    {
        base.Update();
        CurrentState.LogicUpdate();
    }

    protected override void FixedUpdate()
    {
        CurrentState.PhysicsUpdate();
        base.FixedUpdate();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        CurrentState.OnCollisionEnter(collision);
    }

    protected override void OnCollisionStay2D(Collision2D collision)
    {
        base.OnCollisionStay2D(collision);
        CurrentState.OnCollisionStay(collision);
    }

    protected override void OnCollisionExit2D(Collision2D collision)
    {
        base.OnCollisionExit2D(collision);
        CurrentState.OnCollisionExit(collision);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        CurrentState.OnTriggerEnter(collision);
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        CurrentState.OnTriggerEnter(collision);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        CurrentState.OnTriggerExit(collision);
    }

    public void ChangeState(EntityState newState)
    {
        if (changeStateCoroutine != null)
            StopCoroutine(changeStateCoroutine);

        CurrentState.Exit();
        PreviousState = CurrentState;
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void ChangeState(EntityState newState, float t) 
    {
        changeStateCoroutine = StartCoroutine(ChangeStateAfterSec(newState, t));
    }

    private IEnumerator ChangeStateAfterSec(EntityState newState, float t)
    {
        yield return new WaitForSeconds(t);
        ChangeState(newState);
    }

    protected abstract void SetupStateMachine();
}
