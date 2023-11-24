using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : Skill
{
    private float maxBarrierDurabilty = 10;
    private float barrierDurability;

    private Coroutine regenerateDurabiltyCoroutine;

    public Barrier(CombatEntity entity) : base(entity)
    {
    }

    public override void EnablePassive()
    {
        regenerateDurabiltyCoroutine = entity.StartCoroutine(RegenerateDurabilty());
    }

    public override void DisablePassive()
    {
        throw new System.NotImplementedException();
    }

    public override void Effect()
    {
        if (barrierDurability <= 0)
            entity.Invulnerable = false;
        else
            entity.Invulnerable = true;
    }

    public override void OnTakeDamage(float dmg)
    {
        base.OnTakeDamage(dmg);
        if (barrierDurability > 0) 
        {
            barrierDurability -= dmg;
            if (barrierDurability <= 0)
            {
                entity.ModifyHp(-barrierDurability);
                barrierDurability = 0;
                entity.Invulnerable = false;
            }
        }
        if (regenerateDurabiltyCoroutine == null)
        {
            regenerateDurabiltyCoroutine = entity.StartCoroutine(RegenerateDurabilty());
        }
    }

    private IEnumerator RegenerateDurabilty()
    {
        WaitForSeconds waitTime = new WaitForSeconds(5);
        while (true)
        {
            yield return waitTime;
            if (barrierDurability < maxBarrierDurabilty)
            {
                barrierDurability += 2f;
                entity.Invulnerable = true;
                if (barrierDurability > maxBarrierDurabilty)
                {
                    barrierDurability = maxBarrierDurabilty;
                    entity.StopCoroutine(regenerateDurabiltyCoroutine);
                    regenerateDurabiltyCoroutine = null;
                }
            }
        }
    }
}
