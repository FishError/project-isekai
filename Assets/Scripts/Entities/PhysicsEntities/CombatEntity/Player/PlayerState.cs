using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerState : EntityState
{
    public Player Player { get; private set; }

    public PlayerState(Player player)
    {
        Player = player;
    }

    public virtual void OnJump() { }

    public virtual void OnMove(InputAction.CallbackContext value) { }

    public virtual void OnLeftClick(Vector2 mousePos, Vector2 relativeMousePos) 
    {
        SetAnimatorMouseValues(relativeMousePos);
    }

    public virtual void OnRightClick(Vector2 mousePos, Vector2 relativeMousePos) 
    {
        
    }

    protected void SetAnimatorMouseValues(Vector2 mousePos)
    {
        Player.weapon.animator.SetFloat("xMouse", mousePos.x);
        Player.weapon.animator.SetFloat("yMouse", mousePos.y);
    }
}
