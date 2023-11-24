using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Active
{
    public float cooldown;

    public abstract void Invoke();
}
