using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool isInsideOfPlayer;

    public EnemyState currentEnemyState;

    private EnemyHealth enemyHealth;
   private EnemyAnimator enemyAnimator;
    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void Start()
    {
        MakeDesicion();
    }

    public void MakeDesicion()
    {

        if (enemyHealth.currentHealth <= 0)
        {
            currentEnemyState = EnemyState.Die;
            enemyAnimator.SetTrigger("Die");
        }
        else if (isInsideOfPlayer)
        {
            currentEnemyState = EnemyState.Attack;
            enemyAnimator.SetTrigger("Attack");
        }
        else
        {
            currentEnemyState = EnemyState.Walk;
            enemyAnimator.SetTrigger("Run");
        }

    }
}

public enum EnemyState
{
    Null,
    Idle,
    Walk,
    Attack,
    Die,
}