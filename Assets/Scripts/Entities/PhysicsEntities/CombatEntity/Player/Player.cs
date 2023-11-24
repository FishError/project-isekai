using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : ComplexCombatEntity
{
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerAirBorneState AirBorneState { get; private set; }
    public PlayerBasicAttackState BasicAttackState { get; private set; }
    public PlayerBasicAttackAirState BasicAttackAirState { get; private set; }


    public Active Active1 { get; set; }
    public Active Active2 { get; set; }
    public Active Active3 { get; set; }
    public Active Active4 { get; set; }
    public Active Active5 { get; set; }
    public OnJumpSkill OnJumpSkill { get; private set; }

    public PlayerInputController playerInput;

    public Weapon weapon;

    protected override void Start()
    {
        base.Start();
        OnJumpSkill = new DoubleJump(this);
        Active1 = new TestActiveSkill(this).Actives.First();
    }

    protected override void Update()
    {
        base.Update();
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("xVelocity", rb.velocity.x);
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
        BasicAttackState = new PlayerBasicAttackState(this);
        BasicAttackAirState = new PlayerBasicAttackAirState(this);
        CurrentState = IdleState;
    }

    public void Jump()
    {
        velocities.Add(new Vector2(0, 7));
        playerInput.IsJumping = true;
    }
}
