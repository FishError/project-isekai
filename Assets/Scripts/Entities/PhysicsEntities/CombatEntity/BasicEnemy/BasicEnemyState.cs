using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicEnemyState : EntityState
{
    public BasicEnemy BasicEnemy { get; private set; }

    public BasicEnemyState(BasicEnemy basicEnemy)
    {
        BasicEnemy = basicEnemy;
    }
}
