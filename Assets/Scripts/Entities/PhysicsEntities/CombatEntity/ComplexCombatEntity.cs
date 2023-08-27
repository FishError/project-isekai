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
        ChangeState(newState, t);
    }

    protected abstract void SetupStateMachine();
}
