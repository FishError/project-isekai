using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlimeState : EntityState
{
    public Slime Slime { get; private set; }

    public SlimeState(Slime slime)
    {
        Slime = slime;
    }
}
