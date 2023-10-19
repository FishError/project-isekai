using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Enemy : ComplexCombatEntity
{
    public GameObject target;
    public Vector3 targetPos;
    public Vector3 targetDir;

    public Player playerRef;
    public LayerMask playerLayer;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (target == null)
            FOV();

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

    protected override void SetBaseStats()
    {
        base.SetBaseStats();
        CalculateRelativeSpd();
    }

    protected void CalculateRelativeSpd()
    {
        if (playerRef == null)
            playerRef = FindObjectOfType<Player>();
        RelativeSpd *= (Spd / playerRef.Spd);
    }

    public void FOV()
    {
        Collider2D[] entities = Physics2D.OverlapCircleAll(transform.position, 5, playerLayer);
        if (entities.Length > 0)
        {
            Transform target = entities[0].transform;
            Vector2 direction = (target.position - transform.position).normalized;
            if (Vector2.Angle(transform.right, direction) < 30)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 5, terrainLayer);
                if (hit.transform == null)
                {
                    this.target = target.gameObject;
                }
            }
        }
    }
}
