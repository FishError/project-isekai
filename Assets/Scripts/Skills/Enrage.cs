using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enrage : Skill
{
    private readonly float strBuff = 0.2f;

    private Coroutine buffAttackCoroutine;
    private Coroutine removeBuffCoroutine;

    public Enrage(CombatEntity entity) : base(entity) 
    {
        
    }

    public override void EnablePassive()
    {
        buffAttackCoroutine = entity.StartCoroutine(BuffStr());
    }

    public override void DisablePassive()
    {
        if (buffAttackCoroutine != null)
        {
            entity.StopCoroutine(buffAttackCoroutine);
        }
        else if (removeBuffCoroutine != null)
        {
            entity.ModifyStr(-entity.Str * strBuff);
            entity.StopCoroutine(removeBuffCoroutine);
        }
    }

    private IEnumerator BuffStr()
    {
        yield return new WaitUntil(() => entity.CurrentHp <= entity.Hp * 0.2f);
        entity.ModifyStr(entity.Str * strBuff);
        removeBuffCoroutine = entity.StartCoroutine(RemoveBuff());
        buffAttackCoroutine = null;
    }

    private IEnumerator RemoveBuff()
    {
        yield return new WaitUntil(() => entity.CurrentHp > entity.Hp * 0.2f);
        entity.ModifyStr(-entity.Str * strBuff);
        buffAttackCoroutine = entity.StartCoroutine(BuffStr());
        removeBuffCoroutine = null;
    }
}
