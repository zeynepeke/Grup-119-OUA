using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckAICollider : MonoBehaviour
{
    [SerializeField] private EnemyAI enemyAI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyAI.isInsideOfPlayer = true;
            enemyAI.MakeDesicion();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyAI.isInsideOfPlayer = false;
            enemyAI.MakeDesicion();
        }
    }
}