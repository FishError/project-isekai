using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ComplexCombatEntity
{
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerAirBorneState AirBorneState { get; private set; }

    public PlayerInputController playerInput;

    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void SetupStateMachine()
    {
        IdleState = new PlayerIdleState(this);
        MoveState = new PlayerMoveState(this);
        AirBorneState = new PlayerAirBorneState(this);
        CurrentState = IdleState;
    }

    public override void SetBaseStats(CombatEntityData data)
    {
        throw new System.NotImplementedException();
    }
}
