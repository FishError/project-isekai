using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public SlimeIdleState IdleState { get; private set; }
    public SlimeMoveState MoveState { get; private set; }
    public SlimeAirBorneState AirBorneState { get; private set; }
    public SlimeLeapState LeapState { get; private set; }

    protected override void SetupStateMachine()
    {
        IdleState = new SlimeIdleState(this);
        MoveState = new SlimeMoveState(this);
        AirBorneState = new SlimeAirBorneState(this);
        LeapState = new SlimeLeapState(this);
        CurrentState = IdleState;
    }

    protected override void Update()
    {
        base.Update();
    }
}
