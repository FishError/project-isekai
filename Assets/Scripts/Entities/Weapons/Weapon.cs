using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public abstract class Weapon : Entity
{
    public WeaponData data;

    public Player player;

    public int Lvl { get; set; }
    public float Atk { get; protected set; }

    protected virtual void Start()
    {
        Atk = data.Atk;
    }

    protected virtual void Update()
    {
        
    }

    public virtual void OnEquip()
    {

    }

    public virtual void OnRemove() 
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void OnAnimationEnter()
    {
        SetAnimatorBoolToFalse("BasicAttack");
        SetAnimatorBoolToFalse("UpAttack");
        SetAnimatorBoolToFalse("AirAttack");
        if (player.grounded)
        {
            player.BasicAttackState.OnAnimationEnter();
        }
    }

    public void OnAnimationEnd()
    {
        if (player.grounded)
        {
            player.BasicAttackState.OnAnimationEnd();
        }
        else
        {
            player.BasicAttackAirState.OnAnimationEnd();
        }
    }
}
