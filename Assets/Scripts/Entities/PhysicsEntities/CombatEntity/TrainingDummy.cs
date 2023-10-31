using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : SimpleCombatEntity
{
    public override void ModifyHp(float amt)
    {
        base.ModifyHp(amt);
        GetComponentInChildren<EntityUIOverlayController>().SetHpBar();
    }
}
