using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : SimpleCombatEntity
{
    public override void ModifyHP(float amt)
    {
        base.ModifyHP(amt);
        GetComponentInChildren<EntityUIOverlayController>().SetHpBar();
    }
}
