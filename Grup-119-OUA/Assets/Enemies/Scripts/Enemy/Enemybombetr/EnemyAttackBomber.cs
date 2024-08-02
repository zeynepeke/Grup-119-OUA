using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBomber : EnemyAttackBase
{
    private void Update()
    {
        if (enemyAI.currentEnemyState == EnemyState.Attack)
        {
            PlayerHealth.instance.DecreaseHealth(damage);
            this.enabled = false;
        }
    }
}