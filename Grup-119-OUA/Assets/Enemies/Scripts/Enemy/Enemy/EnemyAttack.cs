using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyAttackBase
{
    [SerializeField] private float attackDelay;

    private float attackTimer;

    public override void Awake()
    {
        base.Awake();
        attackTimer = attackDelay;
    }

    private void Update()
    {
        if (enemyAI.currentEnemyState == EnemyState.Attack)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer < 0)
            {
                PlayerHealth.instance.DecreaseHealth(damage);
                attackTimer = attackDelay;
            }
        }
    }
}