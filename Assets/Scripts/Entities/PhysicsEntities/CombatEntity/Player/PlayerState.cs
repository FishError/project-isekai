using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : EntityState
{
    public Player Player { get; private set; }

    public PlayerState(Player player)
    {
        Player = player;
    }

    public abstract void OnJump();
}
