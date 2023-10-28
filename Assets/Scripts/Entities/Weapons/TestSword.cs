using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSword : Weapon
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        CombatEntity entity = collision.attachedRigidbody.GetComponent<CombatEntity>();
        if (entity != null)
        {
            entity.ApplyPhysicalDmg(player.CurrentStr + Atk);
        }
    }
}
