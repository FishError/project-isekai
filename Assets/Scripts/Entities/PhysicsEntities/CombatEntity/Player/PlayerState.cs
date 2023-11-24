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

    public virtual void OnActive1()
    {
        if (Player.Active1 != null)
            Player.Active1.Invoke();
    }

    public virtual void OnActive2()
    {
        if (Player.Active2 != null)
            Player.Active2.Invoke();
    }

    public virtual void OnActive3()
    {
        if (Player.Active3 != null)
            Player.Active3.Invoke();
    }

    public virtual void OnActive4()
    {
        if (Player.Active4 != null)
            Player.Active4.Invoke();
    }

    public virtual void OnActive5()
    {
        if (Player.Active5 != null)
            Player.Active5.Invoke();
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
