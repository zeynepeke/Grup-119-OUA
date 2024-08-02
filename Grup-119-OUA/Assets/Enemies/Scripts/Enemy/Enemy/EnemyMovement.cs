using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;

    private Transform player;

    private EnemyAI enemyAI;

    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (enemyAI.currentEnemyState == EnemyState.Walk)
        {
            transform.LookAt(player.position);
            transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
        }
    }
}