using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : ComplexCombatEntity
{
    public GameObject target;
    public Vector3 targetPos;
    public Vector3 targetDir;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (target != null )
        {
            targetPos = target.transform.position;
            targetDir = (targetPos - transform.position).normalized;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
